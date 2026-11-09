using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class P_Clientes : Form
    {
        private D_Clientes objDatos = new D_Clientes();
        private List<E_Cliente> listaCompletaClientes = new List<E_Cliente>();
        private string Texto = "Buscar por Código, Razón Social, Nombre Comercial o RUC";
        public P_Clientes()
        {
            InitializeComponent();
        }

        private async void P_Clientes_Load(object sender, EventArgs e)
        {
            // Configurar placeholder inicial del buscador
            txtBuscar.Text = Texto;
            txtBuscar.ForeColor = Color.Gray;

            // Enlazar eventos de foco para el placeholder (asegúrate de enlazarlos en el diseñador o aquí)
            txtBuscar.Enter -= txtBuscar_Enter;
            txtBuscar.Enter += txtBuscar_Enter;
            txtBuscar.Leave -= txtBuscar_Leave;
            txtBuscar.Leave += txtBuscar_Leave;
            txtBuscar.TextChanged -= txtBuscar_TextChanged;
            txtBuscar.TextChanged += txtBuscar_TextChanged;

            dtgv_Clientes.AutoGenerateColumns = false;
            await CargarTablaClientes();
        }

        private async Task CargarTablaClientes()
        {
            try
            {
                listaCompletaClientes = await objDatos.ObtenerClientes();

                dtgv_Clientes.DataSource = null;
                dtgv_Clientes.DataSource = listaCompletaClientes;

                // Actualizar el Label con el total inicial
                ActualizarContador();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar clientes: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ActualizarContador()
        {
            int total = dtgv_Clientes.Rows.Count;
            // Asegúrate de usar el nombre de tu Label (ej: label2 o lblTotalClientes)
            lbl_Cliente.Text = $"Total Clientes: {total}";
        }

        #region Buscador

        private void txtBuscar_Click(object sender, EventArgs e)
        {
            txtBuscar.Clear();
        }

        private async void dtgv_Clientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                E_Cliente clienteSeleccionado = dtgv_Clientes.Rows[e.RowIndex].DataBoundItem as E_Cliente;

                if (clienteSeleccionado != null)
                {
                    string codigoCliente = clienteSeleccionado.codigo_cliente;

                    // Prioriza el Nombre Comercial; si está vacío, usa la Razón Social
                    string nombreCliente = !string.IsNullOrWhiteSpace(clienteSeleccionado.nombre_comercial)
                        ? clienteSeleccionado.nombre_comercial
                        : clienteSeleccionado.razon_social;

                    P_Principal principal = Application.OpenForms.OfType<P_Principal>().FirstOrDefault();

                    if (principal != null)
                    {
                        // Se envían Código (filtrado) y Nombre Comercial (exportación Excel)
                        P_Extintores frmExtintores = new P_Extintores(codigoCliente, nombreCliente);
                        principal.openChildForm(frmExtintores);
                    }
                }
            }
        }



        private void btnBuscar_Click(object sender, EventArgs e)
        {
            FiltrarTabla();
        }

        private void dtgv_Clientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            FiltrarTabla();
        }

        private void FiltrarTabla()
        {
            string filtro = txtBuscar.Text.Trim().ToLower();

            // Si el buscador está vacío o tiene el texto por defecto, mostrar todo
            if (filtro == Texto.ToLower() || string.IsNullOrWhiteSpace(filtro))
            {
                dtgv_Clientes.DataSource = null;
                dtgv_Clientes.DataSource = listaCompletaClientes;
                return;
            }

            // Filtrar por código_cliente, razon_social, nombre_comercial o ruc
            var listaFiltrada = listaCompletaClientes.Where(x =>
                (x.codigo_cliente != null && x.codigo_cliente.ToLower().Contains(filtro)) ||
                (x.razon_social != null && x.razon_social.ToLower().Contains(filtro)) ||
                (x.nombre_comercial != null && x.nombre_comercial.ToLower().Contains(filtro)) ||
                (x.ruc != null && x.ruc.ToLower().Contains(filtro))
            ).ToList();

            // Actualizar la grilla con los datos filtrados
            dtgv_Clientes.DataSource = null;
            dtgv_Clientes.DataSource = listaFiltrada;

            ActualizarContador();
        }
        #endregion
    }
}