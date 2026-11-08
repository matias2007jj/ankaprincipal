using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class P_Clientes : Form
    {
        private D_Clientes objDatos = new D_Clientes();

        public P_Clientes()
        {
            InitializeComponent();
        }

        private async void P_Clientes_Load(object sender, EventArgs e)
        {
            dtgv_Clientes.AutoGenerateColumns = false;
            await CargarTablaClientes();
        }

        private async Task CargarTablaClientes()
        {
            try
            {
                List<E_Cliente> lista = await objDatos.ObtenerClientes();
                dtgv_Clientes.DataSource = lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar clientes: " + ex.Message);
            }
        }

        private void txtBuscar_Click(object sender, EventArgs e)
        {
            txtBuscar.Clear();
        }

        private async void dtgv_Clientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                E_Cliente clienteSeleccionado = (E_Cliente)dtgv_Clientes.Rows[e.RowIndex].DataBoundItem;
                string codigoCliente = clienteSeleccionado.codigo_cliente;

                P_Principal principal = Application.OpenForms.OfType<P_Principal>().FirstOrDefault();

                if (principal != null)
                {
                    // El propio constructor y el Load de P_Extintores se encargarán de cargar los 186 registros
                    P_Extintores frmExtintores = new P_Extintores(codigoCliente);
                    principal.openChildForm(frmExtintores);
                }
            }
        }
    }
}