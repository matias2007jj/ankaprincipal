using CapaNegocio;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class LOGIN : Form
    {
        private readonly N_Usuario objNegocio = new N_Usuario();

        #region Mover Formulario sin Bordes

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private static extern void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private static extern void SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void panelTitulo_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, 0x112, 0xf012, 0);
            }
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
            Application.Exit();
        }

        private void txt_Contraseña_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btn_Ingresar.PerformClick();
            }
        }

        private void btn_Mostrar_Click(object sender, EventArgs e)
        {
            txt_Contraseña.UseSystemPasswordChar = !txt_Contraseña.UseSystemPasswordChar;
        }

        private async void btn_Ingresar_Click(object sender, EventArgs e)
        {
            string usuario = txt_Usuario.Text.Trim();
            string password = txt_Contraseña.Text.Trim();

            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Por favor, ingrese usuario y contraseña.", "Campos Requeridos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_Usuario.Focus();
                return;
            }

            btn_Ingresar.Enabled = false;
            btn_Ingresar.Text = "Verificando...";

            try
            {
                bool loginExitoso = await objNegocio.ValidarLogin(usuario, password);

                if (loginExitoso)
                {
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

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}