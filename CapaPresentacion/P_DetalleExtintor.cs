using CapaDatos;
using CapaEntidad;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static CapaEntidad.E_Catalogos;

namespace CapaPresentacion
{
    public partial class P_DetalleExtintor : Form
    {

        private bool ValidarCampos()
        {
            // Invocación a la clase validadora
            ResultadoValidacion resultado = ValidadorExtintor.ValidarFormulario(
                txtNroSerie,
                cboEstado,
                cboTipoExtintor,
                cboCapacidad,
                cboMarca,
                cboSede,
                txtAnioFabricacion
            );

            // Si hay un error, muestra el mensaje y pone el foco en el control que falló
            if (!resultado.EsValido)
            {
                MessageBox.Show(resultado.Mensaje, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                if (resultado.ControlConError != null)
                {
                    resultado.ControlConError.Focus();
                    if (resultado.ControlConError is TextBox txt)
                    {
                        txt.SelectAll();
                    }
                }
                return false;
            }

            return true;
        }

        private E_Extintor extintorActual = null;
        private string codigoClienteActual = "";

        private D_Catalogos objCatalogos = new D_Catalogos();
        private D_Documentos objDatosDocs = new D_Documentos();

        private List<E_Documento> listaDocsAdjuntos = new List<E_Documento>();
        private string rutaDocumentoSeleccionadoTemp = "";

        // 1. Constructor sin parámetros (Diseñador Visual de VS)
        public P_DetalleExtintor()
        {
            InitializeComponent();
            VincularEventosControles();
        }

        // 2. Constructor para Registro Nuevo
        public P_DetalleExtintor(string codigoCliente) : this()
        {
            this.codigoClienteActual = codigoCliente;
            this.Text = "Ficha Técnica de Extintor - Nuevo";
        }

        // 3. Constructor para Edición de Registro
        public P_DetalleExtintor(string codigoCliente, E_Extintor extintor) : this(codigoCliente)
        {
            this.extintorActual = extintor;
            this.Text = "Ficha Técnica - " + extintor.codigo_u;
        }

        // Vincular eventos manualmente para asegurar funcionamiento continuo
        private void VincularEventosControles()
        {
            this.Load += new EventHandler(P_DetalleExtintor_Load);

            if (btnGuardar != null) btnGuardar.Click += new EventHandler(btnGuardar_Click);
            if (btnCancelar != null) btnCancelar.Click += new EventHandler(btnCancelar_Click);

            if (btnExaminar != null) btnExaminar.Click += new EventHandler(btnExaminar_Click);
            if (btnAgregarDocumento != null) btnAgregarDocumento.Click += new EventHandler(btnAgregarDocumento_Click);
            if (btnQuitarDocumento != null) btnQuitarDocumento.Click += new EventHandler(btnQuitarDocumento_Click);

            if (txtNroCertificado != null) txtNroCertificado.Leave += new EventHandler(txtNroCertificado_Leave);

            // Subscripción limpia a cambio de fechas y año de fabricación
            if (dtpFechaServicio != null) dtpFechaServicio.ValueChanged += new EventHandler(dtpFechaServicio_ValueChanged);
            if (dtpFechaPruebaHidro != null) dtpFechaPruebaHidro.ValueChanged += new EventHandler(dtpFechaPruebaHidro_ValueChanged);
            if (txtAnioFabricacion != null) txtAnioFabricacion.TextChanged += new EventHandler(txtAnioFabricacion_TextChanged);
        }

        private async void P_DetalleExtintor_Load(object sender, EventArgs e)
        {
            // --- APLICAR REGLAS DE INTERFAZ DESDE LA CLASE VALIDADORA ---

            // 1. Bloquea la edición manual en todos los ComboBox
            ValidadorExtintor.ConfigurarSoloSeleccion(cboEstado, cboTipoExtintor, cboCapacidad, cboMarca, cboSede, cboTipoDocumento);

            // 2. Permite ÚNICAMENTE números en estos campos de texto
            ValidadorExtintor.PermitirSoloNumeros(txtNroSerie, txtNroInterno, txtAnioFabricacion, txtNroCertificado);

            // 3. Activa el salto a la siguiente casilla al presionar ENTER
            ValidadorExtintor.ActivarNavegacionEnter(this);

            // --- CARGA DE DATOS NORMAL ---
            ConfigurarFormatosFecha();
            CargarComboTiposDocumento();
            await CargarCatalogosGenerales();
            await CargarSedesCliente();

            if (extintorActual != null)
            {
                txtCodigoU.ReadOnly = true;
                MapearDatosFicha();
            }
            else
            {
                await GenerarSiguienteCodigoUnico();
                CalcularProximoMantenimiento();
                CalcularVencimientoPH();
            }
        }

        private async Task GenerarSiguienteCodigoUnico()
        {
            txtCodigoU.ReadOnly = true;
            txtCodigoU.Text = "Cargando...";

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync("https://intranet.ankafire.com.pe/obtener_extintores.php");
                    if (response.IsSuccessStatusCode)
                    {
                        string json = await response.Content.ReadAsStringAsync();
                        List<E_Extintor> lista = JsonConvert.DeserializeObject<List<E_Extintor>>(json);

                        if (lista != null && lista.Count > 0)
                        {
                            int maxId = lista.Max(x => x.id);
                            txtCodigoU.Text = $"AF-EXT-{(maxId + 1):D6}";
                        }
                        else
                        {
                            txtCodigoU.Text = "AF-EXT-000001";
                        }
                    }
                    else
                    {
                        txtCodigoU.Text = "AF-EXT-AUTOGEN";
                    }
                }
            }
            catch
            {
                txtCodigoU.Text = "AF-EXT-AUTOGEN";
            }
        }

        private void ConfigurarFormatosFecha()
        {
            DateTimePicker[] controlesFecha = { dtpFechaServicio, dtpFechaPruebaHidro };

            foreach (var dtp in controlesFecha)
            {
                if (dtp != null)
                {
                    dtp.Format = DateTimePickerFormat.Custom;
                    dtp.CustomFormat = "MMMM - yyyy";
                    dtp.ShowUpDown = true;
                }
            }
        }

        private void CargarComboTiposDocumento()
        {
            cboTipoDocumento.Items.Clear();
            cboTipoDocumento.Items.Add("Certificado de Operatividad");
            cboTipoDocumento.Items.Add("Informe Técnico");
            cboTipoDocumento.Items.Add("Certificado de PH");
            cboTipoDocumento.SelectedIndex = 0;
        }

        private async Task CargarCatalogosGenerales()
        {
            try
            {
                E_RespuestaCatalogos res = await objCatalogos.ObtenerCatalogosWeb();

                if (res != null && res.exito)
                {
                    cboTipoExtintor.DataSource = null;
                    cboTipoExtintor.DisplayMember = "nombre";
                    cboTipoExtintor.ValueMember = "id";
                    cboTipoExtintor.DataSource = res.tipos;

                    cboCapacidad.DataSource = null;
                    cboCapacidad.DisplayMember = "valor";
                    cboCapacidad.ValueMember = "id";
                    cboCapacidad.DataSource = res.capacidades;

                    cboMarca.DataSource = null;
                    cboMarca.DisplayMember = "nombre";
                    cboMarca.ValueMember = "id";
                    cboMarca.DataSource = res.marcas;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar desplegables generales: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task CargarSedesCliente()
        {
            if (string.IsNullOrWhiteSpace(codigoClienteActual)) return;

            try
            {
                List<E_Sede> listaSedes = await objCatalogos.ObtenerSedesPorCliente(codigoClienteActual);

                cboSede.DataSource = null;
                cboSede.DisplayMember = "nombre_sede";
                cboSede.ValueMember = "id";
                cboSede.DataSource = listaSedes;

                cboSede.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cboSede.AutoCompleteSource = AutoCompleteSource.ListItems;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las sedes del cliente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MapearDatosFicha()
        {
            txtCodigoU.Text = extintorActual.codigo_u;
            txtNroSerie.Text = extintorActual.nro_serie;
            txtNroInterno.Text = extintorActual.nro_interno;
            txtAnioFabricacion.Text = extintorActual.anio_fabricacion;
            txtUbicacion.Text = extintorActual.ubicacion;
            cboEstado.Text = extintorActual.estado;

            if (txtNroCertificado != null && !string.IsNullOrEmpty(extintorActual.nro_certificado))
                txtNroCertificado.Text = extintorActual.nro_certificado;

            if (!string.IsNullOrEmpty(extintorActual.marca))
                cboMarca.Text = extintorActual.marca;

            if (!string.IsNullOrEmpty(extintorActual.sede))
                cboSede.Text = extintorActual.sede;

            if (!string.IsNullOrEmpty(extintorActual.tipo))
                cboTipoExtintor.Text = extintorActual.tipo;

            if (!string.IsNullOrEmpty(extintorActual.capacidad))
                cboCapacidad.Text = extintorActual.capacidad;

            if (DateTime.TryParse(extintorActual.eje_servicio, out DateTime fServ))
                dtpFechaServicio.Value = fServ;

            if (DateTime.TryParse(extintorActual.fecha_prueba_hidrostatica, out DateTime fPH))
                dtpFechaPruebaHidro.Value = fPH;

            CalcularProximoMantenimiento();
            CalcularVencimientoPH();

            // Mapeo e hidratación de la grilla de documentos adjuntos guardados previamente
            listaDocsAdjuntos.Clear();

            if (!string.IsNullOrEmpty(extintorActual.ruta_cert_operatividad))
            {
                listaDocsAdjuntos.Add(new E_Documento
                {
                    tipo_documento = "Certificado de Operatividad",
                    nombre_archivo = Path.GetFileName(extintorActual.ruta_cert_operatividad),
                    ruta_web = extintorActual.ruta_cert_operatividad,
                    ruta_local = ""
                });
            }

            if (!string.IsNullOrEmpty(extintorActual.ruta_informe_tecnico))
            {
                listaDocsAdjuntos.Add(new E_Documento
                {
                    tipo_documento = "Informe Técnico",
                    nombre_archivo = Path.GetFileName(extintorActual.ruta_informe_tecnico),
                    ruta_web = extintorActual.ruta_informe_tecnico,
                    ruta_local = ""
                });
            }

            if (!string.IsNullOrEmpty(extintorActual.ruta_cert_ph))
            {
                listaDocsAdjuntos.Add(new E_Documento
                {
                    tipo_documento = "Certificado de PH",
                    nombre_archivo = Path.GetFileName(extintorActual.ruta_cert_ph),
                    ruta_web = extintorActual.ruta_cert_ph,
                    ruta_local = ""
                });
            }

            RefrescarGrillaDocumentos();
        }

        private void RefrescarGrillaDocumentos()
        {
            if (dtgvDocumentos != null)
            {
                dtgvDocumentos.DataSource = null;
                dtgvDocumentos.DataSource = listaDocsAdjuntos;
            }
        }

        #region Reglas de Negocio para Fechas y Atajo de Certificados

        private void dtpFechaServicio_ValueChanged(object sender, EventArgs e)
        {
            CalcularProximoMantenimiento();
        }

        private void CalcularProximoMantenimiento()
        {
            DateTime fechaEjecucion = dtpFechaServicio.Value;
            DateTime proximoMantenimiento = fechaEjecucion.AddYears(1);

            string textoFecha = proximoMantenimiento.ToString("MMMM - yyyy").ToUpper();

            if (ProxMantenimientoCalculado != null)
                ProxMantenimientoCalculado.Text = textoFecha;
        }

        private void dtpFechaPruebaHidro_ValueChanged(object sender, EventArgs e)
        {
            CalcularVencimientoPH();
        }

        private void txtAnioFabricacion_TextChanged(object sender, EventArgs e)
        {
            CalcularVencimientoPH();
        }

        private void CalcularVencimientoPH()
        {
            DateTime fechaBase;

            if (dtpFechaPruebaHidro != null && dtpFechaPruebaHidro.Value != DateTime.MinValue)
            {
                fechaBase = dtpFechaPruebaHidro.Value;
            }
            else if (int.TryParse(txtAnioFabricacion.Text.Trim(), out int anioFab) && anioFab > 1900)
            {
                fechaBase = new DateTime(anioFab, 1, 1);
            }
            else
            {
                fechaBase = DateTime.Now;
            }

            DateTime vencimientoPH = fechaBase.AddYears(5);
            string textoFecha = vencimientoPH.ToString("MMMM - yyyy").ToUpper();

            if (VencimientoPHCalculado != null)
                VencimientoPHCalculado.Text = textoFecha;
        }

        private async void txtNroCertificado_Leave(object sender, EventArgs e)
        {
            string nroCert = txtNroCertificado.Text.Trim();
            if (string.IsNullOrEmpty(nroCert)) return;

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string url = $"https://intranet.ankafire.com.pe/buscar_documentos_certificado.php?codigo={Uri.EscapeDataString(nroCert)}";
                    HttpResponseMessage response = await client.GetAsync(url);
                    string json = await response.Content.ReadAsStringAsync();

                    dynamic res = JsonConvert.DeserializeObject(json);

                    if (res != null && (bool)res.exito && res.documentos != null && res.documentos.Count > 0)
                    {
                        int agregados = 0;
                        foreach (var item in res.documentos)
                        {
                            string rutaWeb = (string)item.ruta_web;
                            string nombreArch = (string)item.nombre_archivo;
                            string tipoDoc = (string)item.tipo_documento;

                            if (!listaDocsAdjuntos.Exists(d => d.ruta_web == rutaWeb))
                            {
                                listaDocsAdjuntos.Add(new E_Documento()
                                {
                                    tipo_documento = tipoDoc,
                                    nombre_archivo = nombreArch,
                                    ruta_web = rutaWeb,
                                    ruta_local = ""
                                });
                                agregados++;
                            }
                        }

                        if (agregados > 0)
                        {
                            RefrescarGrillaDocumentos();
                            MessageBox.Show($"Se asociaron automáticamente {agregados} documento(s) del certificado '{nroCert}'.",
                                            "Atajo Aplicado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch
            {
                // Mantiene el flujo si no hay resultados
            }
        }

        #endregion

        #region Gestión Dinámica de Documentos PDF

        private void btnExaminar_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Seleccionar Documento (PDF)";
                ofd.Filter = "Documentos PDF (*.pdf)|*.pdf";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    rutaDocumentoSeleccionadoTemp = ofd.FileName;

                    if (txtRutaArchivoSeleccionado != null)
                        txtRutaArchivoSeleccionado.Text = Path.GetFileName(rutaDocumentoSeleccionadoTemp);
                }
            }
        }

        private void btnAgregarDocumento_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(rutaDocumentoSeleccionadoTemp))
            {
                MessageBox.Show("Seleccione un archivo PDF antes de agregar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            E_Documento doc = new E_Documento()
            {
                tipo_documento = cboTipoDocumento.SelectedItem != null ? cboTipoDocumento.SelectedItem.ToString() : "Otro Documento",
                nombre_archivo = Path.GetFileName(rutaDocumentoSeleccionadoTemp),
                ruta_local = rutaDocumentoSeleccionadoTemp,
                ruta_web = ""
            };

            listaDocsAdjuntos.Add(doc);
            RefrescarGrillaDocumentos();

            rutaDocumentoSeleccionadoTemp = "";
            if (txtRutaArchivoSeleccionado != null) txtRutaArchivoSeleccionado.Text = "";
        }

        private void btnQuitarDocumento_Click(object sender, EventArgs e)
        {
            if (dtgvDocumentos != null && dtgvDocumentos.CurrentRow != null)
            {
                int index = dtgvDocumentos.CurrentRow.Index;
                if (index >= 0 && index < listaDocsAdjuntos.Count)
                {
                    // Remueve el documento seleccionado de la memoria
                    listaDocsAdjuntos.RemoveAt(index);
                    RefrescarGrillaDocumentos();
                }
            }
            else
            {
                MessageBox.Show("Seleccione una fila en la tabla de documentos para eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        #endregion

        #region Guardar Registro y Subir Archivos a Hostinger

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            // Invocar la validación de la clase antes de continuar
            if (!ValidarCampos()) return;

            try
            {
                this.UseWaitCursor = true;
                btnGuardar.Enabled = false;

                // Subir solo archivos nuevos agregados desde la PC local
                foreach (var doc in listaDocsAdjuntos)
                {
                    if (!string.IsNullOrEmpty(doc.ruta_local) && File.Exists(doc.ruta_local) && string.IsNullOrEmpty(doc.ruta_web))
                    {
                        doc.ruta_web = await objDatosDocs.SubirDocumentoWeb(doc.ruta_local);
                    }
                }

                string valorSede = cboSede.SelectedValue != null ? cboSede.SelectedValue.ToString() : cboSede.Text;

                var datosExtintor = new
                {
                    id = extintorActual?.id,
                    codigo_u = txtCodigoU.Text,
                    codigo_cliente = codigoClienteActual,
                    nro_certificado = txtNroCertificado != null ? txtNroCertificado.Text.Trim() : "",
                    nro_serie = txtNroSerie.Text.Trim(),
                    nro_interno = txtNroInterno.Text.Trim(),
                    tipo = cboTipoExtintor.Text,
                    capacidad = cboCapacidad.Text,
                    marca = cboMarca.Text,
                    anio_fabricacion = txtAnioFabricacion.Text.Trim(),
                    sede = valorSede,
                    ubicacion = txtUbicacion.Text.Trim(),
                    eje_servicio = dtpFechaServicio.Value.ToString("yyyy-MM-01"),
                    proximo_mantenimiento = dtpFechaServicio.Value.AddYears(1).ToString("yyyy-MM-01"),
                    fecha_prueba_hidrostatica = dtpFechaPruebaHidro.Value.ToString("yyyy-MM-01"),
                    vencimiento_ph = dtpFechaPruebaHidro.Value.AddYears(5).ToString("yyyy-MM-01"),
                    estado = cboEstado.Text,
                    documentos = listaDocsAdjuntos
                };

                using (HttpClient client = new HttpClient())
                {
                    string jsonPayload = JsonConvert.SerializeObject(datosExtintor);
                    var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync("https://intranet.ankafire.com.pe/guardar_extintor.php", content);
                    string respuestaServidor = await response.Content.ReadAsStringAsync();

                    dynamic res = JsonConvert.DeserializeObject(respuestaServidor);

                    if (res != null && (bool)res.exito)
                    {
                        MessageBox.Show($"Extintor registrado correctamente con el código {res.codigo_u} y {listaDocsAdjuntos.Count} documento(s) asociado(s).",
                                        "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        throw new Exception((string)res?.mensaje ?? "Error al procesar en la base de datos.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.UseWaitCursor = false;
                btnGuardar.Enabled = true;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        private void P_DetalleExtintor_Load_1(object sender, EventArgs e)
        {

        }
    }
}