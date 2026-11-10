using CapaDatos;
using CapaEntidad;
using CapaNegocio;
using ClosedXML.Excel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class P_Extintores : Form
    {
        private readonly N_Extintores objNegocio = new N_Extintores();
        private List<E_Extintor> listaCompletaExtintores = new List<E_Extintor>();
        private string Texto = "Buscar por NºSerie, Codigo.U, Marca, Sede o Tipo";
        private string clienteFiltro = null;
        private string clienteNombre = null;

        public P_Extintores()
        {
            InitializeComponent();
        }

        public P_Extintores(string codigoCliente, string nombreCliente = null) : this()
        {
            this.clienteFiltro = codigoCliente;
            this.clienteNombre = nombreCliente;
        }

        private async void P_Extintores_Load(object sender, EventArgs e)
        {
            txtBuscar.Text = Texto;
            txtBuscar.ForeColor = Color.Gray;
            dtgv_Extintores.AutoGenerateColumns = false;

            // Asegurar suscripción de eventos
            dtgv_Extintores.CellContentClick -= dtgv_Extintores_CellContentClick;
            dtgv_Extintores.CellContentClick += dtgv_Extintores_CellContentClick;

            dtgv_Extintores.CellFormatting -= dtgv_Extintores_CellFormatting;
            dtgv_Extintores.CellFormatting += dtgv_Extintores_CellFormatting;

            // Evento para capturar el Enter enviado por Barcode to PC o lectoras QR
            txtBuscar.KeyDown -= txtBuscar_KeyDown;
            txtBuscar.KeyDown += txtBuscar_KeyDown;

            ConfigurarMapeoColumnas();
            AgregarColumnaDocumentacion();

            await CargarDatosWeb(clienteFiltro);
        }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Previene el sonido de alerta de Windows
                LimpiarUrlBarcodeToPC();
                FiltrarTabla();
            }
        }

        private void LimpiarUrlBarcodeToPC()
        {
            string textoLeido = txtBuscar.Text.Trim();

            // Si el QR escaneado contiene una URL (ej. https://intranet.ankafire.com.pe/extintor/AF-EXT-000609)
            if (textoLeido.Contains("/"))
            {
                string[] partes = textoLeido.Split('/');
                string codigoExtraido = partes[partes.Length - 1].Trim();

                if (!string.IsNullOrWhiteSpace(codigoExtraido))
                {
                    txtBuscar.Text = codigoExtraido;
                }
            }
        }

        private void ConfigurarMapeoColumnas()
        {
            foreach (DataGridViewColumn col in dtgv_Extintores.Columns)
            {
                string header = col.HeaderText.Trim().ToLower();
                string name = col.Name.Trim().ToLower();

                if (header == "sede" || name.Contains("sede"))
                {
                    col.DataPropertyName = "sede";
                }
                else if (header == "ubicación" || header == "ubicacion" || name.Contains("ubicacion"))
                {
                    col.DataPropertyName = "ubicacion";
                }
                else if (header.Contains("codigo") || header.Contains("cod"))
                {
                    col.DataPropertyName = "codigo_u";
                }
                else if (header.Contains("serie"))
                {
                    col.DataPropertyName = "nro_serie";
                }
                else if (header.Contains("interno"))
                {
                    col.DataPropertyName = "nro_interno";
                }
                else if (header == "tipo")
                {
                    col.DataPropertyName = "tipo";
                }
                else if (header.Contains("capacidad"))
                {
                    col.DataPropertyName = "capacidad";
                }
                else if (header == "marca")
                {
                    col.DataPropertyName = "marca";
                }
                else if (header.Contains("fabricacion"))
                {
                    col.DataPropertyName = "anio_fabricacion";
                }
                else if (header.Contains("ejecución") || header.Contains("servicio"))
                {
                    col.DataPropertyName = "eje_servicio";
                }
                else if (header.Contains("mantenimiento") || header.Contains("prox"))
                {
                    col.DataPropertyName = "proximo_mantenimiento";
                }
                else if (header.Contains("prueba h"))
                {
                    col.DataPropertyName = "fecha_prueba_hidrostatica";
                }
                else if (header.Contains("venc"))
                {
                    col.DataPropertyName = "vencimiento_ph";
                }
                else if (header == "estado")
                {
                    col.DataPropertyName = "estado";
                }
            }
        }

        private void AgregarColumnaDocumentacion()
        {
            if (!dtgv_Extintores.Columns.Contains("btnCertificado"))
            {
                DataGridViewButtonColumn colCert = new DataGridViewButtonColumn();
                colCert.Name = "btnCertificado";
                colCert.HeaderText = "DOCUMENTACIÓN";
                colCert.UseColumnTextForButtonValue = false; // Texto dinámico por celda
                colCert.FlatStyle = FlatStyle.Flat;
                colCert.DefaultCellStyle.ForeColor = Color.FromArgb(227, 6, 19);
                colCert.DefaultCellStyle.Font = new Font("Arial", 8.5f, FontStyle.Bold);

                int indexAcciones = dtgv_Extintores.Columns.Contains("btnEditar")
                    ? dtgv_Extintores.Columns["btnEditar"].Index
                    : dtgv_Extintores.Columns.Count;

                if (indexAcciones > dtgv_Extintores.Columns.Count)
                    indexAcciones = dtgv_Extintores.Columns.Count;

                dtgv_Extintores.Columns.Insert(indexAcciones, colCert);
            }
        }

        private void dtgv_Extintores_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dtgv_Extintores.Columns[e.ColumnIndex].Name == "btnCertificado")
            {
                E_Extintor extintor = dtgv_Extintores.Rows[e.RowIndex].DataBoundItem as E_Extintor;
                if (extintor != null)
                {
                    if (!string.IsNullOrWhiteSpace(extintor.ruta_informe_tecnico))
                    {
                        e.Value = "Informe Técnico";
                    }
                    else if (!string.IsNullOrWhiteSpace(extintor.ruta_cert_operatividad))
                    {
                        e.Value = "Cert. Operatividad";
                    }
                    else if (!string.IsNullOrWhiteSpace(extintor.ruta_cert_ph))
                    {
                        e.Value = "Cert. Prueba H.";
                    }
                    else
                    {
                        e.Value = "Sin Documento";
                    }
                }
            }
        }

        public async Task CargarDatosWeb(string codigoClienteFiltro = null)
        {
            try
            {
                this.UseWaitCursor = true;

                List<E_Extintor> todos = await objNegocio.ListarExtintores();

                foreach (var item in todos)
                {
                    item.eje_servicio = FormatearMesAnio(item.eje_servicio);
                    item.proximo_mantenimiento = FormatearMesAnio(item.proximo_mantenimiento);
                    item.fecha_prueba_hidrostatica = FormatearMesAnio(item.fecha_prueba_hidrostatica);
                    item.vencimiento_ph = FormatearMesAnio(item.vencimiento_ph);
                }

                if (!string.IsNullOrWhiteSpace(codigoClienteFiltro))
                {
                    string filtroLimpio = codigoClienteFiltro.Trim();
                    listaCompletaExtintores = todos
                        .Where(x => x.codigo_cliente != null && x.codigo_cliente.Trim() == filtroLimpio)
                        .ToList();
                }
                else
                {
                    listaCompletaExtintores = todos;
                }

                dtgv_Extintores.DataSource = null;
                dtgv_Extintores.DataSource = listaCompletaExtintores;
                ActualizarContador();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar extintores: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.UseWaitCursor = false;
            }
        }

        private string FormatearMesAnio(string fechaTexto)
        {
            if (string.IsNullOrWhiteSpace(fechaTexto)) return "";

            if (fechaTexto.Contains("-") && fechaTexto.Length <= 9 && !char.IsDigit(fechaTexto[0]))
            {
                return fechaTexto.ToUpper();
            }

            if (DateTime.TryParse(fechaTexto, out DateTime fechaParsed))
            {
                string mesAbreviado = fechaParsed.ToString("MMM", new CultureInfo("es-ES")).Replace(".", "").ToUpper();
                return $"{mesAbreviado}.-{fechaParsed.Year}";
            }

            return fechaTexto;
        }

        #region Buscador

        private void txtBuscar_Click(object sender, EventArgs e)
        {
            if (txtBuscar.Text != Texto)
            {
                txtBuscar.SelectionStart = txtBuscar.Text.Length;
                txtBuscar.ScrollToCaret();
            }
        }

        private void txtBuscar_Enter(object sender, EventArgs e)
        {
            if (txtBuscar.Text == Texto)
            {
                txtBuscar.Text = "";
                txtBuscar.ForeColor = Color.Black;
            }
        }

        private void txtBuscar_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBuscar.Text))
            {
                txtBuscar.Text = Texto;
                txtBuscar.ForeColor = Color.Gray;
                this.ActiveControl = null;
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            FiltrarTabla();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            LimpiarUrlBarcodeToPC();
            FiltrarTabla();
        }

        private void FiltrarTabla()
        {
            string filtro = txtBuscar.Text.Trim().ToLower();

            if (filtro == Texto.ToLower() || string.IsNullOrWhiteSpace(filtro))
            {
                dtgv_Extintores.DataSource = listaCompletaExtintores;
                ActualizarContador();
                return;
            }

            // Si contiene barras de URL, extrae únicamente el código final
            if (filtro.Contains("/"))
            {
                string[] segmentos = filtro.Split('/');
                filtro = segmentos[segmentos.Length - 1].ToLower();
            }

            var listaFiltrada = listaCompletaExtintores.Where(x =>
                (x.nro_serie != null && x.nro_serie.ToLower().Contains(filtro)) ||
                (x.codigo_u != null && x.codigo_u.ToLower().Contains(filtro)) ||
                (x.marca != null && x.marca.ToLower().Contains(filtro)) ||
                (x.sede != null && x.sede.ToLower().Contains(filtro)) ||
                (x.ubicacion != null && x.ubicacion.ToLower().Contains(filtro)) ||
                (x.tipo != null && x.tipo.ToLower().Contains(filtro))
            ).ToList();

            dtgv_Extintores.DataSource = null;
            dtgv_Extintores.DataSource = listaFiltrada;
            ActualizarContador();
        }

        #endregion

        #region Eventos de Acciones

        private async void dtgv_Extintores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewColumn col = dtgv_Extintores.Columns[e.ColumnIndex];
            string nombreColumna = col.Name.Trim().ToLower();
            string tituloColumna = col.HeaderText.Trim().ToLower();

            bool esBotonCertificado = nombreColumna == "btncertificado" ||
                                     tituloColumna.Contains("documentación") ||
                                     tituloColumna.Contains("documentacion");

            bool esBotonEditar = nombreColumna == "btneditar" ||
                                 nombreColumna.Contains("editar") ||
                                 tituloColumna == "editar";

            bool esBotonEliminar = nombreColumna == "btneliminar" ||
                                   nombreColumna.Contains("eliminar") ||
                                   tituloColumna == "eliminar";

            bool esBotonQR = nombreColumna == "btnqr" ||
                             nombreColumna.Contains("qr") ||
                             tituloColumna == "qr";

            E_Extintor seleccionado = dtgv_Extintores.Rows[e.RowIndex].DataBoundItem as E_Extintor;

            if (seleccionado == null) return;

            if (esBotonCertificado)
            {
                string rutaCert = !string.IsNullOrWhiteSpace(seleccionado.ruta_informe_tecnico)
                    ? seleccionado.ruta_informe_tecnico
                    : (!string.IsNullOrWhiteSpace(seleccionado.ruta_cert_operatividad) ? seleccionado.ruta_cert_operatividad : seleccionado.ruta_cert_ph);

                if (!string.IsNullOrWhiteSpace(rutaCert))
                {
                    rutaCert = rutaCert.Trim().TrimStart('/');

                    if (!rutaCert.StartsWith("storage/", StringComparison.OrdinalIgnoreCase) &&
                        !rutaCert.StartsWith("http", StringComparison.OrdinalIgnoreCase))
                    {
                        rutaCert = "storage/" + rutaCert;
                    }

                    if (!rutaCert.StartsWith("http", StringComparison.OrdinalIgnoreCase))
                    {
                        rutaCert = "https://intranet.ankafire.com.pe/" + rutaCert;
                    }

                    try
                    {
                        Process.Start(new ProcessStartInfo
                        {
                            FileName = rutaCert,
                            UseShellExecute = true
                        });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al abrir el documento: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Este extintor no tiene ningún documento adjunto.", "Documentación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else if (esBotonEditar)
            {
                P_DetalleExtintor frmFicha = new P_DetalleExtintor(clienteFiltro, seleccionado);
                if (frmFicha.ShowDialog() == DialogResult.OK)
                {
                    await CargarDatosWeb(clienteFiltro);
                }
            }
            else if (esBotonEliminar)
            {
                DialogResult respuesta = MessageBox.Show(
                    $"¿Está seguro de que desea dar de BAJA al extintor {seleccionado.codigo_u}?",
                    "Confirmar Dar de Baja",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (respuesta == DialogResult.Yes)
                {
                    await DarDeBajaExtintorWeb(seleccionado.id);
                }
            }
            else if (esBotonQR)
            {
                P_ImprimirQR frmQR = new P_ImprimirQR(seleccionado);
                frmQR.ShowDialog();
            }
        }

        private async Task DarDeBajaExtintorWeb(int idExtintor)
        {
            try
            {
                this.UseWaitCursor = true;

                using (HttpClient client = new HttpClient())
                {
                    var payload = new { id = idExtintor };
                    string jsonPayload = JsonConvert.SerializeObject(payload);
                    var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync("https://intranet.ankafire.com.pe/eliminar_extintor.php", content);
                    string jsonResponse = await response.Content.ReadAsStringAsync();

                    dynamic res = JsonConvert.DeserializeObject(jsonResponse);

                    if (res != null && (bool)res.exito)
                    {
                        MessageBox.Show("El extintor ha sido pasado a estado 'De Baja' exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await CargarDatosWeb(clienteFiltro);
                    }
                    else
                    {
                        string mensajeError = res?.mensaje != null ? res.mensaje.ToString() : "Error al procesar la baja.";
                        MessageBox.Show(mensajeError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de conexión: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.UseWaitCursor = false;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            P_DetalleExtintor frmFicha = new P_DetalleExtintor(clienteFiltro);
            if (frmFicha.ShowDialog() == DialogResult.OK)
            {
                _ = CargarDatosWeb(clienteFiltro);
            }
        }

        #endregion

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ActualizarContador()
        {
            int total = dtgv_Extintores.Rows.Count;
            lbl_Extintores.Text = $"Total Extintores: {total}";
        }

        private void btn_ExportarExcel_Click(object sender, EventArgs e)
        {
            if (dtgv_Extintores.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos cargados para exportar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string nombreMostrar = !string.IsNullOrWhiteSpace(clienteNombre)
                ? clienteNombre.ToUpper()
                : (!string.IsNullOrWhiteSpace(clienteFiltro) ? clienteFiltro : "TODOS LOS CLIENTES");

            string nombreArchivoSanitizado = string.Join("_", nombreMostrar.Split(Path.GetInvalidFileNameChars()));

            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Archivo de Excel (*.xlsx)|*.xlsx",
                FileName = $"Reporte_Extintores_{nombreArchivoSanitizado}_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (XLWorkbook workbook = new XLWorkbook())
                    {
                        var worksheet = workbook.Worksheets.Add("Extintores");

                        // 1. TÍTULO Y NOMBRE COMERCIAL DEL CLIENTE
                        worksheet.Cell(1, 1).Value = "ANKA FIRE - REPORTE DE EXTINTORES";
                        worksheet.Cell(1, 1).Style.Font.Bold = true;
                        worksheet.Cell(1, 1).Style.Font.FontSize = 14;

                        worksheet.Cell(2, 1).Value = $"CLIENTE: {nombreMostrar}";
                        worksheet.Cell(2, 1).Style.Font.Bold = true;
                        worksheet.Cell(2, 1).Style.Font.FontSize = 11;
                        worksheet.Cell(2, 1).Style.Font.FontColor = XLColor.FromArgb(227, 6, 19);

                        // 2. ENCABEZADOS DE LA TABLA (Fila 4)
                        int filaInicioTabla = 4;
                        int colIndex = 1;
                        for (int i = 0; i < dtgv_Extintores.Columns.Count; i++)
                        {
                            var col = dtgv_Extintores.Columns[i];
                            if (col.Visible && !(col is DataGridViewButtonColumn))
                            {
                                var cell = worksheet.Cell(filaInicioTabla, colIndex);
                                cell.Value = col.HeaderText;
                                cell.Style.Font.Bold = true;
                                cell.Style.Fill.BackgroundColor = XLColor.FromArgb(227, 6, 19);
                                cell.Style.Font.FontColor = XLColor.White;
                                colIndex++;
                            }
                        }

                        // 3. FILAS DE DATOS
                        for (int r = 0; r < dtgv_Extintores.Rows.Count; r++)
                        {
                            colIndex = 1;
                            for (int c = 0; c < dtgv_Extintores.Columns.Count; c++)
                            {
                                var col = dtgv_Extintores.Columns[c];
                                if (col.Visible && !(col is DataGridViewButtonColumn))
                                {
                                    object valor = dtgv_Extintores.Rows[r].Cells[c].Value;
                                    worksheet.Cell(r + filaInicioTabla + 1, colIndex).Value = valor?.ToString() ?? "";
                                    colIndex++;
                                }
                            }
                        }

                        // 4. ALINEACIÓN Y FORMATO DE CELDAS
                        int totalColumnas = colIndex - 1;
                        int ultimaFila = filaInicioTabla + dtgv_Extintores.Rows.Count;

                        var rangoTabla = worksheet.Range(filaInicioTabla, 1, ultimaFila, totalColumnas);
                        rangoTabla.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        rangoTabla.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;

                        rangoTabla.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                        rangoTabla.Style.Border.InsideBorder = XLBorderStyleValues.Thin;
                        rangoTabla.Style.Border.OutsideBorderColor = XLColor.LightGray;
                        rangoTabla.Style.Border.InsideBorderColor = XLColor.LightGray;

                        // 5. AUTOAJUSTAR ANCHO DE COLUMNAS
                        worksheet.Columns().AdjustToContents();

                        workbook.SaveAs(saveFileDialog.FileName);
                    }

                    MessageBox.Show($"Archivo Excel generado con éxito para {nombreMostrar}.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al exportar a Excel: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btn_ImportarExcel_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Archivos de Excel (*.xlsx;*.xls)|*.xlsx;*.xls",
                Title = "Seleccionar Excel de Extintores"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    this.UseWaitCursor = true;
                    List<E_Extintor> nuevosExtintores = new List<E_Extintor>();

                    using (XLWorkbook workbook = new XLWorkbook(openFileDialog.FileName))
                    {
                        IXLWorksheet worksheet = workbook.Worksheet(1);
                        var rows = worksheet.RangeUsed().RowsUsed().Skip(1);

                        foreach (var row in rows)
                        {
                            E_Extintor extintor = new E_Extintor
                            {
                                nro_serie = row.Cell(1).GetValue<string>().Trim(),
                                nro_interno = row.Cell(2).GetValue<string>().Trim(),
                                sede = row.Cell(3).GetValue<string>().Trim(),
                                ubicacion = row.Cell(4).GetValue<string>().Trim(),
                                tipo = row.Cell(5).GetValue<string>().Trim(),
                                capacidad = row.Cell(6).GetValue<string>().Trim(),
                                marca = row.Cell(7).GetValue<string>().Trim(),
                                anio_fabricacion = row.Cell(8).GetValue<string>().Trim(),
                                eje_servicio = FormatearMesAnio(row.Cell(9).GetValue<string>()),
                                proximo_mantenimiento = FormatearMesAnio(row.Cell(10).GetValue<string>()),
                                fecha_prueba_hidrostatica = FormatearMesAnio(row.Cell(11).GetValue<string>()),
                                vencimiento_ph = FormatearMesAnio(row.Cell(12).GetValue<string>()),
                                estado = string.IsNullOrWhiteSpace(row.Cell(13).GetValue<string>()) ? "Vigente" : row.Cell(13).GetValue<string>().Trim()
                            };

                            extintor.codigo_cliente = clienteFiltro;

                            if (!string.IsNullOrWhiteSpace(extintor.nro_serie) || !string.IsNullOrWhiteSpace(extintor.codigo_u))
                            {
                                nuevosExtintores.Add(extintor);
                            }
                        }
                    }

                    if (nuevosExtintores.Count > 0)
                    {
                        listaCompletaExtintores.AddRange(nuevosExtintores);

                        dtgv_Extintores.DataSource = null;
                        dtgv_Extintores.DataSource = listaCompletaExtintores;
                        ActualizarContador();

                        MessageBox.Show($"Se importaron {nuevosExtintores.Count} extintores correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No se encontraron registros válidos en el archivo Excel.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al leer el archivo Excel: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    this.UseWaitCursor = false;
                }
            }
        }

        private void lbl_Extintores_Click(object sender, EventArgs e)
        {

        }
    }
}