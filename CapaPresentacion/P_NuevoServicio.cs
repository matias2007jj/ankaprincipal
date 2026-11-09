using CapaDatos;
using CapaEntidad;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class P_NuevoServicio : Form
    {
        private E_Extintor extintorActual;
        private string rutaFotoLocalTemp = "";
        private D_Documentos objDatosDocs = new D_Documentos();

        private ComboBox cboTipoServicio;
        private TextBox txtDescripcion;
        private TextBox txtObservaciones;
        private PictureBox picFoto;
        private Button btnExaminarFoto;
        private Button btnGuardar;
        private Button btnCancelar;
        private Label lblFechaHora;
        private Label lblHeaderEmpresa;

        public P_NuevoServicio(E_Extintor extintor)
        {
            InitializeComponent();
            this.extintorActual = extintor;
            this.Text = "Registrar Servicio - " + extintor.codigo_u;
            this.Size = new Size(520, 560);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            ConstruirInterfaz();
            this.Load += P_NuevoServicio_Load;
        }

        private async void P_NuevoServicio_Load(object sender, EventArgs e)
        {
            // Intentar obtener el nombre del cliente basado en el codigo_cliente (ej. AF-CLI-001)
            string codCliente = !string.IsNullOrWhiteSpace(extintorActual.codigo_cliente)
                ? extintorActual.codigo_cliente
                : extintorActual.nombre_cliente;

            if (!string.IsNullOrWhiteSpace(codCliente))
            {
                string razonSocialReal = await ObtenerNombreClientePorCodigo(codCliente);
                if (!string.IsNullOrWhiteSpace(razonSocialReal))
                {
                    extintorActual.nombre_cliente = razonSocialReal;
                    string sedeEmpresa = !string.IsNullOrWhiteSpace(extintorActual.sede) ? extintorActual.sede : "PRINCIPAL";
                    lblHeaderEmpresa.Text = $"EMPRESA: {razonSocialReal.ToUpper()}  |  SEDE: {sedeEmpresa.ToUpper()}";
                }
            }
        }

        private async Task<string> ObtenerNombreClientePorCodigo(string codCliente)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string json = await client.GetStringAsync("https://intranet.ankafire.com.pe/obtener_clientes.php");
                    if (!string.IsNullOrWhiteSpace(json))
                    {
                        json = json.Trim();
                        List<Dictionary<string, object>> listaClientes = null;

                        // Caso 1: Si el JSON viene directamente como arreglo [...]
                        if (json.StartsWith("["))
                        {
                            listaClientes = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(json);
                        }
                        // Caso 2: Si viene envuelto en {"clientes": [...]} u objeto similar
                        else if (json.StartsWith("{"))
                        {
                            dynamic res = JsonConvert.DeserializeObject(json);
                            if (res != null)
                            {
                                string contenidoInterno = res.clientes != null ? res.clientes.ToString() : json;
                                listaClientes = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(contenidoInterno);
                            }
                        }

                        if (listaClientes != null)
                        {
                            foreach (var cli in listaClientes)
                            {
                                string codigoEncontrado = "";
                                if (cli.ContainsKey("codigo_cliente") && cli["codigo_cliente"] != null)
                                    codigoEncontrado = cli["codigo_cliente"].ToString().Trim();
                                else if (cli.ContainsKey("codigo") && cli["codigo"] != null)
                                    codigoEncontrado = cli["codigo"].ToString().Trim();

                                if (codigoEncontrado.Equals(codCliente.Trim(), StringComparison.OrdinalIgnoreCase))
                                {
                                    if (cli.ContainsKey("razon_social") && cli["razon_social"] != null && !string.IsNullOrWhiteSpace(cli["razon_social"].ToString()))
                                    {
                                        return cli["razon_social"].ToString().Trim();
                                    }
                                    if (cli.ContainsKey("nombre_comercial") && cli["nombre_comercial"] != null && !string.IsNullOrWhiteSpace(cli["nombre_comercial"].ToString()))
                                    {
                                        return cli["nombre_comercial"].ToString().Trim();
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error obteniendo cliente: " + ex.Message);
            }
            return "";
        }

        private void ConstruirInterfaz()
        {
            this.Controls.Clear();

            int y = 15;

            string empresa = !string.IsNullOrWhiteSpace(extintorActual.nombre_cliente)
                ? extintorActual.nombre_cliente
                : (!string.IsNullOrWhiteSpace(extintorActual.codigo_cliente) ? extintorActual.codigo_cliente : "GENERAL");

            string sedeEmpresa = !string.IsNullOrWhiteSpace(extintorActual.sede) ? extintorActual.sede : "PRINCIPAL";
            string capacidad = !string.IsNullOrWhiteSpace(extintorActual.capacidad) ? extintorActual.capacidad : "N/A";

            // Encabezado 1: EMPRESA (Razón Social) | SEDE
            lblHeaderEmpresa = new Label
            {
                Text = $"EMPRESA: {empresa.ToUpper()}  |  SEDE: {sedeEmpresa.ToUpper()}",
                Location = new Point(20, y),
                Size = new Size(460, 20),
                Font = new Font("Arial", 10, FontStyle.Bold),
                ForeColor = Color.DarkRed
            };
            this.Controls.Add(lblHeaderEmpresa);
            y += 22;

            // Encabezado 2: Tipo, Capacidad, Marca y Nº Serie
            Label lblHeaderDetalles = new Label
            {
                Text = $"Tipo: {extintorActual.tipo}  |  Capacidad: {capacidad}  |  Marca: {extintorActual.marca}  |  Serie: {extintorActual.nro_serie}",
                Location = new Point(20, y),
                Size = new Size(460, 20),
                Font = new Font("Arial", 8.5f, FontStyle.Bold),
                ForeColor = Color.DarkSlateGray
            };
            this.Controls.Add(lblHeaderDetalles);
            y += 30;

            // Tipo de Servicio
            Label lblTipo = new Label { Text = "Tipo de Servicio:", Location = new Point(20, y), Size = new Size(120, 20) };
            cboTipoServicio = new ComboBox
            {
                Location = new Point(150, y),
                Size = new Size(330, 25),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cboTipoServicio.Items.AddRange(new object[] {
                "Mantenimiento Anual",
                "Recarga",
                "Prueba Hidrostática",
                "Inspección Rutinaria",
                "Cambio de Manguera / Manómetro",
                "Otro Servicio"
            });
            cboTipoServicio.SelectedIndex = 0;
            this.Controls.Add(lblTipo);
            this.Controls.Add(cboTipoServicio);
            y += 35;

            // Descripción
            Label lblDesc = new Label { Text = "Descripción:", Location = new Point(20, y), Size = new Size(120, 20) };
            txtDescripcion = new TextBox { Location = new Point(150, y), Size = new Size(330, 50), Multiline = true, ScrollBars = ScrollBars.Vertical };
            this.Controls.Add(lblDesc);
            this.Controls.Add(txtDescripcion);
            y += 60;

            // Observaciones
            Label lblObs = new Label { Text = "Observaciones:", Location = new Point(20, y), Size = new Size(120, 20) };
            txtObservaciones = new TextBox { Location = new Point(150, y), Size = new Size(330, 50), Multiline = true, ScrollBars = ScrollBars.Vertical };
            this.Controls.Add(lblObs);
            this.Controls.Add(txtObservaciones);
            y += 60;

            // Foto
            Label lblFoto = new Label { Text = "Foto (Opcional):", Location = new Point(20, y), Size = new Size(120, 20) };
            picFoto = new PictureBox
            {
                Location = new Point(150, y),
                Size = new Size(120, 100),
                BorderStyle = BorderStyle.FixedSingle,
                SizeMode = PictureBoxSizeMode.Zoom
            };
            btnExaminarFoto = new Button
            {
                Text = "Subir Foto",
                Location = new Point(280, y),
                Size = new Size(100, 30)
            };
            btnExaminarFoto.Click += BtnExaminarFoto_Click;
            this.Controls.Add(lblFoto);
            this.Controls.Add(picFoto);
            this.Controls.Add(btnExaminarFoto);
            y += 115;

            // Fecha/Hora Automática
            lblFechaHora = new Label
            {
                Text = "Fecha de registro: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm"),
                Location = new Point(20, y),
                Size = new Size(460, 20),
                Font = new Font("Arial", 9, FontStyle.Italic),
                ForeColor = Color.Gray
            };
            this.Controls.Add(lblFechaHora);
            y += 35;

            // Botones Guardar / Cancelar
            btnGuardar = new Button
            {
                Text = "Guardar Servicio",
                Location = new Point(150, y),
                Size = new Size(140, 35),
                BackColor = Color.FromArgb(227, 6, 19),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Arial", 9, FontStyle.Bold)
            };
            btnGuardar.Click += BtnGuardar_Click;

            btnCancelar = new Button
            {
                Text = "Cancelar",
                Location = new Point(300, y),
                Size = new Size(100, 35)
            };
            btnCancelar.Click += (s, e) => this.Close();

            this.Controls.Add(btnGuardar);
            this.Controls.Add(btnCancelar);
        }

        private void BtnExaminarFoto_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Seleccionar Imagen del Servicio";
                ofd.Filter = "Archivos de Imagen (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    rutaFotoLocalTemp = ofd.FileName;
                    picFoto.Image = Image.FromFile(rutaFotoLocalTemp);
                }
            }
        }

        private async void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                MessageBox.Show("Por favor, ingrese una breve descripción del servicio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDescripcion.Focus();
                return;
            }

            try
            {
                this.UseWaitCursor = true;
                btnGuardar.Enabled = false;

                string rutaFotoWeb = "";
                if (!string.IsNullOrEmpty(rutaFotoLocalTemp) && File.Exists(rutaFotoLocalTemp))
                {
                    rutaFotoWeb = await objDatosDocs.SubirDocumentoWeb(rutaFotoLocalTemp);
                }

                var payload = new
                {
                    id_extintor = extintorActual.id,
                    codigo_u = extintorActual.codigo_u,
                    tipo_servicio = cboTipoServicio.SelectedItem.ToString(),
                    descripcion = txtDescripcion.Text.Trim(),
                    observaciones = txtObservaciones.Text.Trim(),
                    ruta_foto = rutaFotoWeb
                };

                using (HttpClient client = new HttpClient())
                {
                    string jsonPayload = JsonConvert.SerializeObject(payload);
                    var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync("https://intranet.ankafire.com.pe/guardar_historial_servicio.php", content);
                    string jsonResponse = await response.Content.ReadAsStringAsync();

                    if (!string.IsNullOrWhiteSpace(jsonResponse) && jsonResponse.TrimStart().StartsWith("{"))
                    {
                        dynamic res = JsonConvert.DeserializeObject(jsonResponse);

                        if (res != null && (bool)res.exito)
                        {
                            MessageBox.Show("Servicio registrado exitosamente en el historial.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        else
                        {
                            string msg = res?.mensaje != null ? res.mensaje.ToString() : "Error al registrar en la base de datos.";
                            MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("El servidor no devolvió una respuesta válida.", "Error de Servidor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar servicio: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.UseWaitCursor = false;
                btnGuardar.Enabled = true;
            }
        }
    }
}