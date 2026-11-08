using CapaDatos;
using CapaEntidad;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class P_Extintores : Form
    {
        private readonly N_Extintores objNegocio = new N_Extintores();
        private List<E_Extintor> listaCompletaExtintores = new List<E_Extintor>();
        private string Texto = "Buscar por NºSerie, Codigo.U, Marca, Sede o Tipo";
        private string clienteFiltro = null;

        // Constructor por defecto
        public P_Extintores()
        {
            InitializeComponent();
        }

        // Constructor que recibe el código de cliente al hacer doble clic desde P_Clientes
        public P_Extintores(string codigoCliente) : this()
        {
            this.clienteFiltro = codigoCliente;
        }

        private async void P_Extintores_Load(object sender, EventArgs e)
        {
            txtBuscar.Text = Texto;
            txtBuscar.ForeColor = Color.Gray;
            dtgv_Extintores.AutoGenerateColumns = false;

            // Pasa la variable clienteFiltro (si vino desde P_Clientes tendrá valor, si no será null)
            await CargarDatosWeb(clienteFiltro);
        }

        public async Task CargarDatosWeb(string codigoClienteFiltro = null)
        {
            try
            {
                this.UseWaitCursor = true;

                // 1. Obtener la lista completa desde la Capa de Negocio
                List<E_Extintor> todos = await objNegocio.ListarExtintores();

                // 2. Si viene un cliente, filtramos la lista completa que usará el DataGridView y el buscador
                if (!string.IsNullOrWhiteSpace(codigoClienteFiltro))
                {
                    string filtroLimpio = codigoClienteFiltro.Trim();
                    listaCompletaExtintores = todos
                        .Where(x => x.codigo_cliente != null && x.codigo_cliente.Trim() == filtroLimpio)
                        .ToList();
                }
                else
                {
                    listaCompletaExtintores = todos;
                }

                // 3. Refrescar el DataGridView con los datos filtrados
                dtgv_Extintores.DataSource = null;
                dtgv_Extintores.DataSource = listaCompletaExtintores;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.UseWaitCursor = false;
            }
        }

        #region Manejo de Placeholder (Buscador)

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

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            // Filtrado automático mientras escribes
            FiltrarTabla();
        }

        #endregion

        #region Botones de Acción

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            FiltrarTabla();
        }

        private void FiltrarTabla()
        {
            string filtro = txtBuscar.Text.Trim().ToLower();

            if (filtro == Texto.ToLower() || string.IsNullOrWhiteSpace(filtro))
            {
                dtgv_Extintores.DataSource = listaCompletaExtintores;
                return;
            }

            // Filtra la lista por Serie, Código Único, Marca, Sede o Tipo
            var listaFiltrada = listaCompletaExtintores.Where(x =>
                (x.nro_serie != null && x.nro_serie.ToLower().Contains(filtro)) ||
                (x.codigo_u != null && x.codigo_u.ToLower().Contains(filtro)) ||
                (x.marca != null && x.marca.ToLower().Contains(filtro)) ||
                (x.sede != null && x.sede.ToLower().Contains(filtro)) ||
                (x.tipo != null && x.tipo.ToLower().Contains(filtro))
            ).ToList();

            dtgv_Extintores.DataSource = null;
            dtgv_Extintores.DataSource = listaFiltrada;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            // Abrir formulario de registro
        }

        #endregion
    }
}