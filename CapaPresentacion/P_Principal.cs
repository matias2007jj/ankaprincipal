using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;


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



        private void tmOcultarMenu_Tick(object sender, EventArgs e)
        {
            if (PanelMenu.Width - PASO <= ANCHO_MINIMO)
            {
                PanelMenu.Width = ANCHO_MINIMO; // 🔒 Bloquea el ancho a 60 px
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
                PanelMenu.Width = anchoMaximo; // 🔒 Bloquea el ancho exacto inicial
                tmMostrarMenu.Enabled = false;
            }
            else
            {
                PanelMenu.Width += PASO;
            }
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            // Si el ancho es mayor a 100, asumimos que está expandido y lo ocultamos
            if (PanelMenu.Width > ANCHO_MINIMO + 20)
            {
                tmMostrarMenu.Enabled = false;
                tmOcultarMenu.Enabled = true;
            }
            // Si está colapsado, iniciamos la animación para mostrarlo
            else
            {
                tmOcultarMenu.Enabled = false;
                tmMostrarMenu.Enabled = true;
            }
            
            if (PanelMenu.Width > ANCHO_MINIMO + 20)
            {
                pbLogo.Visible = false; // Oculta el logo cuando el menú está colapsado
            }
            else
            {
                pbLogo.Visible = true; // Muestra el logo cuando el menú está expandido
            }


        }

        private void openChildForm(Form childForm)
        {
            // Cierra el formulario hijo actual si existe
            if (this.ActiveMdiChild != null)
            {
                this.ActiveMdiChild.Close();
            }
            // Configura el formulario hijo
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            // Agrega el formulario hijo al panel contenedor
            this.PanelControlador.Controls.Add(childForm);
            this.PanelControlador.Tag = childForm;
            // Muestra el formulario hijo
            childForm.BringToFront();
            childForm.Show();
        }

        private void P_Principal_Load(object sender, EventArgs e)
        {
            anchoMaximo = PanelMenu.Width;
        }

        private void btnExtintores_Click(object sender, EventArgs e)
        {
            openChildForm(new P_Extintores());
            
            btnExtintores.BackColor = Color.OrangeRed;

        }
    }
}
