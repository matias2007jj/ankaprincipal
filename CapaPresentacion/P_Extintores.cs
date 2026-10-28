using System;
using System.Drawing;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class P_Extintores : Form
    {
        public P_Extintores()
        {
            InitializeComponent();
        }

        private string Texto = "Buscar por NºSerie, Codigo.U, Marca, Sede o Tipo";

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
        }

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
                this.ActiveControl = null; // Quita el foco para que no parpadee el cursor
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
          // if (txtBuscar.Text == Texto || string.IsNullOrWhiteSpace(txtBuscar.Text))
          //  {
             //   MessageBox.Show("Ingrese un valor para buscar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
               // return;
          //  }

          // else
           // {
                // Aquí puedes agregar la lógica para realizar la búsqueda con el valor ingresado en txtBuscar.Text
            //    MessageBox.Show($"Buscando: {txtBuscar.Text}", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            dtgv_Extintores.Rows.Add(
                "001",                 // Codigo.U
                "SERIE-123",           // Nº Serie
                "INT-99",              // Nº Interno
                "Sede Central",        // Sede
                "PQS",                 // Tipo
        "6 Kg",                // Capacidad
        "ABC",                 // Marca
        "2023",                // Año Fabricacion
        "Enero 2026",          // Eje. Del Servicio
        "Julio 2026",          // Prox. Mantenimiento
        "10/05/2023",          // Fecha Prueba H.
        "10/05/2028",          // Venc. Prueba H.
        "Operativo",           // Estado
        "Completa"             // Documentacion
    );
        }
    }
}
