using System;
using System.Drawing;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace CapaPresentacion
{
    public partial class LOGIN : Form
    {

        // URL de tu API PHP
        private const string API_LOGIN_URL = "http://tu-servidor-intranet/api/login.php";

        #region Mover Formulario sin Bordes

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private static extern void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private static extern void SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void panelTitulo_MouseMove(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        #endregion

        public LOGIN()
        {
            InitializeComponent();

            txt_Contraseña.UseSystemPasswordChar = true;
        }

        #region Eventos de Controles



        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void txt_Contraseña_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Evita el sonido de alerta al presionar Enter
                btn_Ingresar.PerformClick();
            }
        }

        private void btn_Mostrar_Click(object sender, EventArgs e)
        {
            txt_Contraseña.UseSystemPasswordChar = !txt_Contraseña.UseSystemPasswordChar;
        }

        private void btn_Ingresar_Click(object sender, EventArgs e)
        {
            string usuario = txt_Usuario.Text.Trim();
            string password = txt_Contraseña.Text.Trim();

            // Validar campos vacíos
            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Por favor, ingrese usuario y contraseña.", "Campos Requeridos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_Usuario.Focus();
                return;
            }

            // Cambiar estado del botón para indicar procesamiento
            btn_Ingresar.Enabled = false;
            btn_Ingresar.Text = "Verificando...";

            try
            {
                bool loginExitoso = await AutenticarUsuarioAsync(usuario, password);

                if (loginExitoso)
                {
                    // Abrir el formulario Principal y ocultar el Login
                    P_Principal principal = new P_Principal();
                    principal.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Usuario o contraseña incorrectos.", "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_Contraseña.Clear();
                    txt_Contraseña.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error de conexión con el servidor: {ex.Message}", "Error de Red", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btn_Ingresar.Enabled = true;
                btn_Ingresar.Text = "Ingresar";
            }
        }
            #endregion

            #region Método de Autenticación con Backend PHP

        private async Task<bool> AutenticarUsuarioAsync(string usuario, string password)
        {
            using (HttpClient client = new HttpClient())
            {
                client.Timeout = TimeSpan.FromSeconds(10);

                var loginData = new
                {
                    usuario = usuario,
                    password = password
                };

                string json = JsonConvert.SerializeObject(loginData);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(API_LOGIN_URL, content);

                if (response.IsSuccessStatusCode)
                {
                    string jsonResult = await response.Content.ReadAsStringAsync();
                    dynamic resultado = JsonConvert.DeserializeObject(jsonResult);

                    // Espera una respuesta JSON del tipo: { "success": true }
                    return resultado != null && resultado.success == true;
                }

                return false;
            }
        }

            #endregion
    }
}
