using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class P_Principal : Form
    {
        private int anchoMaximo;
        private const int ANCHO_MINIMO = 58;
        private const int PASO = 45;

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private static extern void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private static extern void SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);

        public P_Principal()
        {
            InitializeComponent();
        }



        private void P_Principal_Load(object sender, EventArgs e)
        {
            anchoMaximo = PanelMenu.Width;
        }

        #region Control de Ventana y Arrastre

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            btnMaximizar.Visible = false;
            btnRestaurar.Visible = true;
            this.WindowState = FormWindowState.Maximized;
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            btnRestaurar.Visible = false;
            btnMaximizar.Visible = true;
            this.WindowState = FormWindowState.Normal;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        #endregion

        #region Animación Menú Lateral

        private void tmOcultarMenu_Tick(object sender, EventArgs e)
        {
            if (PanelMenu.Width - PASO <= ANCHO_MINIMO)
            {
                PanelMenu.Width = ANCHO_MINIMO;
                tmOcultarMenu.Enabled = false;
            }
            else
            {
                PanelMenu.Width -= PASO;
            }
        }

        private void tmMostrarMenu_Tick(object sender, EventArgs e)
        {
            if (PanelMenu.Width + PASO >= anchoMaximo)
            {
                PanelMenu.Width = anchoMaximo;
                tmMostrarMenu.Enabled = false;
            }
            else
            {
                PanelMenu.Width += PASO;
            }
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            if (PanelMenu.Width > ANCHO_MINIMO + 20)
            {
                tmMostrarMenu.Enabled = false;
                tmOcultarMenu.Enabled = true;
                pbLogo.Visible = false;
            }
            else
            {
                tmOcultarMenu.Enabled = false;
                tmMostrarMenu.Enabled = true;
                pbLogo.Visible = true;
            }
        }

        #endregion

        #region Navegación Formularios Hijos

        public void openChildForm(Form childForm)
        {
            if (this.ActiveMdiChild != null)
            {
                this.ActiveMdiChild.Close();
            }

            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            this.PanelControlador.Controls.Add(childForm);
            this.PanelControlador.Tag = childForm;

            childForm.BringToFront();
            childForm.Show();
        }

        // Método auxiliar para gestionar el estado visual de los botones del menú
        private void ResaltarBotonActivo(Button botonActivo)
        {
            // Restablece el color de fondo de todos los botones dentro de PanelMenu
            foreach (Control control in PanelMenu.Controls)
            {
                // Usamos btn.Name != "btnMenu" para evitar errores de compatibilidad de tipos
                if (control is Button btn && btn.Name != "btnMenu")
                {
                    btn.BackColor = Color.Transparent; // O el color de fondo base del panel
                }
            }

            // Destaca únicamente el botón pulsado
            if (botonActivo != null)
            {
                botonActivo.BackColor = Color.OrangeRed;
            }
        }

        private void btnExtintores_Click(object sender, EventArgs e)
        {
            openChildForm(new P_HistorialGeneral());
            ResaltarBotonActivo((Button)sender);

        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            openChildForm(new P_Clientes());
            ResaltarBotonActivo((Button)sender);
        }

        #endregion
    }
}