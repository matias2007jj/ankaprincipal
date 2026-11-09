using CapaDatos;
using CapaEntidad;
using CapaNegocio;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class P_HistorialGeneral : Form
    {
        private E_Extintor extintorSeleccionado = null;
        private List<E_HistorialServicio> listaCompletaHistorial = new List<E_HistorialServicio>();
        private readonly N_Extintores objNegocioExtintores = new N_Extintores();
        private Timer timerEscaneoAuto;

        private DataGridView dtgvHistorial;
        private Button btnNuevoServicio;
        private TextBox txtBuscarQR;
        private Label lblTitulo;
        private Label lblInfoCliente;

        public P_HistorialGeneral()
        {
            InitializeComponent();
            this.Text = "Historial General de Servicios y Mantenimientos";
            InicializarTimerEscaneo();
            ConstruirInterfaz();
        }

        public P_HistorialGeneral(E_Extintor extintor) : this()
        {
            this.extintorSeleccionado = extintor;
            if (extintor != null)
            {
                this.Text = "Historial de Servicios - " + extintor.codigo_u;
            }
        }

        private void InicializarTimerEscaneo()
        {
            timerEscaneoAuto = new Timer();
            timerEscaneoAuto.Interval = 300; // Espera 300ms a que el celular termine de pegar el código
            timerEscaneoAuto.Tick += async (s, e) =>
            {
                timerEscaneoAuto.Stop();
                await ProcesarEscaneoAutomatico();
            };
        }

        private void ConstruirInterfaz()
        {
            this.Controls.Clear();

            // 1. Título General
            lblTitulo = new Label
            {
                Text = "Módulo de Historial y Registro Automático por QR",
                Location = new Point(20, 10),
                Size = new Size(740, 22),
                Font = new Font("Arial", 11, FontStyle.Bold),
                ForeColor = Color.DarkRed
            };
            this.Controls.Add(lblTitulo);

            // 2. Campo para lectura de QR
            Label lblBuscar = new Label
            {
                Text = "Escanear QR:",
                Location = new Point(20, 38),
                Size = new Size(90, 20),
                Font = new Font("Arial", 9, FontStyle.Bold)
            };
            this.Controls.Add(lblBuscar);

            txtBuscarQR = new TextBox
            {
                Location = new Point(115, 36),
                Size = new Size(220, 23),
                Font = new Font("Arial", 9.5f)
            };
            txtBuscarQR.TextChanged += TxtBuscarQR_TextChanged;
            txtBuscarQR.KeyDown += TxtBuscarQR_KeyDown;
            this.Controls.Add(txtBuscarQR);

            // 3. Etiqueta informativa del Extintor / Cliente (Muestra Empresa, Tipo, Marca y Serie)
            lblInfoCliente = new Label
            {
                Text = "Esperando escaneo de etiqueta...",
                Location = new Point(345, 38),
                Size = new Size(415, 20),
                Font = new Font("Arial", 9, FontStyle.Bold),
                ForeColor = Color.Navy
            };
            this.Controls.Add(lblInfoCliente);

            // 4. Grilla de Historial
            dtgvHistorial = new DataGridView
            {
                Location = new Point(20, 70),
                Size = new Size(740, 370),
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                AllowUserToAddRows = false,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right
            };
            dtgvHistorial.CellContentClick += DtgvHistorial_CellContentClick;
            this.Controls.Add(dtgvHistorial);

            this.Load += async (s, e) =>
            {
                await CargarHistorialWeb();
                txtBuscarQR.Focus();
            };
        }

        private void TxtBuscarQR_TextChanged(object sender, EventArgs e)
        {
            timerEscaneoAuto.Stop();
            if (!string.IsNullOrWhiteSpace(txtBuscarQR.Text))
            {
                timerEscaneoAuto.Start();
            }
        }

        private async void TxtBuscarQR_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                timerEscaneoAuto.Stop();
                await ProcesarEscaneoAutomatico();
                e.SuppressKeyPress = true;
            }
        }

        private async Task ProcesarEscaneoAutomatico()
        {
            string codigoIngresado = txtBuscarQR.Text.Trim();

            if (string.IsNullOrWhiteSpace(codigoIngresado))
            {
                dtgvHistorial.DataSource = listaCompletaHistorial;
                lblInfoCliente.Text = "Esperando escaneo de etiqueta...";
                return;
            }

            try
            {
                this.UseWaitCursor = true;

                // Buscar el extintor en MySQL por su Código Único escaneado
                List<E_Extintor> todosExtintores = await objNegocioExtintores.ListarExtintores();
                E_Extintor encontrado = todosExtintores.FirstOrDefault(x =>
                    x.codigo_u != null && x.codigo_u.Trim().Equals(codigoIngresado, StringComparison.OrdinalIgnoreCase));

                if (encontrado != null)
                {
                    this.extintorSeleccionado = encontrado;

                    // Mostrar datos clave: Cliente / Empresa, Tipo, Marca y Serie
                    string nombreEmpresa = !string.IsNullOrEmpty(encontrado.codigo_cliente) ? encontrado.codigo_cliente : "General";
                    lblInfoCliente.Text = $"Empresa: {nombreEmpresa} | Tipo: {encontrado.tipo} | Marca: {encontrado.marca} | Serie: {encontrado.nro_serie}";

                    // Cargar historial previo en la tabla
                    await CargarHistorialWeb();

                    // ABRE AUTOMÁTICAMENTE LA VENTANA DE REGISTRO SIN PRESIONAR NADA
                    txtBuscarQR.Clear();

                    P_NuevoServicio frm = new P_NuevoServicio(encontrado);
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        await CargarHistorialWeb();
                    }
                }
                else
                {
                    // Si es una búsqueda por texto parcial en el historial
                    FiltrarHistorialLocal();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al procesar el extintor: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.UseWaitCursor = false;
                txtBuscarQR.Focus();
            }
        }

        private async Task CargarHistorialWeb()
        {
            try
            {
                this.UseWaitCursor = true;
                using (HttpClient client = new HttpClient())
                {
                    string idParam = extintorSeleccionado != null ? extintorSeleccionado.id.ToString() : "";
                    string url = $"https://intranet.ankafire.com.pe/obtener_historial_servicio.php?id_extintor={idParam}";

                    HttpResponseMessage response = await client.GetAsync(url);
                    string json = await response.Content.ReadAsStringAsync();

                    if (!string.IsNullOrWhiteSpace(json) && json.TrimStart().StartsWith("{"))
                    {
                        dynamic res = JsonConvert.DeserializeObject(json);

                        if (res != null && (bool)res.exito)
                        {
                            listaCompletaHistorial = JsonConvert.DeserializeObject<List<E_HistorialServicio>>(res.historial.ToString());
                            dtgvHistorial.DataSource = listaCompletaHistorial;
                            ConfigurarColumnasGrilla();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener el historial: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.UseWaitCursor = false;
            }
        }

        private void ConfigurarColumnasGrilla()
        {
            if (dtgvHistorial.Columns["id"] != null) dtgvHistorial.Columns["id"].Visible = false;
            if (dtgvHistorial.Columns["id_extintor"] != null) dtgvHistorial.Columns["id_extintor"].Visible = false;
            if (dtgvHistorial.Columns["codigo_u"] != null) dtgvHistorial.Columns["codigo_u"].HeaderText = "Código Único";
            if (dtgvHistorial.Columns["tipo_servicio"] != null) dtgvHistorial.Columns["tipo_servicio"].HeaderText = "Tipo de Servicio";
            if (dtgvHistorial.Columns["descripcion"] != null) dtgvHistorial.Columns["descripcion"].HeaderText = "Descripción";
            if (dtgvHistorial.Columns["observaciones"] != null) dtgvHistorial.Columns["observaciones"].HeaderText = "Observaciones";
            if (dtgvHistorial.Columns["ruta_foto"] != null) dtgvHistorial.Columns["ruta_foto"].HeaderText = "Foto Adjunta";
            if (dtgvHistorial.Columns["fecha_servicio"] != null) dtgvHistorial.Columns["fecha_servicio"].HeaderText = "Fecha / Hora";
        }

        private void FiltrarHistorialLocal()
        {
            string filtro = txtBuscarQR.Text.Trim().ToLower();

            var filtrado = listaCompletaHistorial.Where(h =>
                (h.codigo_u != null && h.codigo_u.ToLower().Contains(filtro)) ||
                (h.tipo_servicio != null && h.tipo_servicio.ToLower().Contains(filtro)) ||
                (h.descripcion != null && h.descripcion.ToLower().Contains(filtro))
            ).ToList();

            dtgvHistorial.DataSource = null;
            dtgvHistorial.DataSource = filtrado;
            ConfigurarColumnasGrilla();
        }

        private void DtgvHistorial_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            E_HistorialServicio item = dtgvHistorial.Rows[e.RowIndex].DataBoundItem as E_HistorialServicio;
            if (item != null && !string.IsNullOrEmpty(item.ruta_foto))
            {
                try
                {
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = item.ruta_foto,
                        UseShellExecute = true
                    });
                }
                catch { }
            }
        }
    }
}