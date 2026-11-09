using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{

    public class ResultadoValidacion
    {
        public bool EsValido { get; set; }
        public string Mensaje { get; set; }
        public Control ControlConError { get; set; }

        public static ResultadoValidacion OK() => new ResultadoValidacion { EsValido = true };

        public static ResultadoValidacion Error(string mensaje, Control control) =>
            new ResultadoValidacion { EsValido = false, Mensaje = mensaje, ControlConError = control };
    }

    internal class ValidadorExtintor
    {
        // ==========================================================
        // 1. VALIDACIÓN DE REGLAS DE NEGOCIO AL GUARDAR
        // ==========================================================
        public static ResultadoValidacion ValidarFormulario(
            TextBox txtNroSerie,
            ComboBox cboEstado,
            ComboBox cboTipoExtintor,
            ComboBox cboCapacidad,
            ComboBox cboMarca,
            ComboBox cboSede,
            TextBox txtAnioFabricacion)
        {
            if (txtNroSerie == null || string.IsNullOrWhiteSpace(txtNroSerie.Text))
                return ResultadoValidacion.Error("El Número de Serie es obligatorio.", txtNroSerie);

            if (cboEstado == null || (cboEstado.SelectedIndex == -1 && string.IsNullOrWhiteSpace(cboEstado.Text)))
                return ResultadoValidacion.Error("Debe seleccionar un Estado para el extintor.", cboEstado);

            if (cboTipoExtintor == null || (cboTipoExtintor.SelectedIndex == -1 && string.IsNullOrWhiteSpace(cboTipoExtintor.Text)))
                return ResultadoValidacion.Error("Debe seleccionar el Tipo de extintor.", cboTipoExtintor);

            if (cboCapacidad == null || (cboCapacidad.SelectedIndex == -1 && string.IsNullOrWhiteSpace(cboCapacidad.Text)))
                return ResultadoValidacion.Error("Debe seleccionar la Capacidad del extintor.", cboCapacidad);

            if (cboMarca == null || (cboMarca.SelectedIndex == -1 && string.IsNullOrWhiteSpace(cboMarca.Text)))
                return ResultadoValidacion.Error("Debe seleccionar la Marca del extintor.", cboMarca);

            if (cboSede == null || (cboSede.SelectedIndex == -1 && string.IsNullOrWhiteSpace(cboSede.Text)))
                return ResultadoValidacion.Error("Debe seleccionar una Sede de la lista.", cboSede);

            if (txtAnioFabricacion != null && !string.IsNullOrWhiteSpace(txtAnioFabricacion.Text))
            {
                int anioActual = DateTime.Now.Year;
                if (!int.TryParse(txtAnioFabricacion.Text.Trim(), out int anio) || anio < 1900 || anio > anioActual + 1)
                {
                    return ResultadoValidacion.Error($"Ingrese un Año de Fabricación válido (entre 1900 y {anioActual + 1}).", txtAnioFabricacion);
                }
            }

            return ResultadoValidacion.OK();
        }

        // ==========================================================
        // 2. BLOQUEO DE ESCRITURA EN COMBOBOX (Solo Selección)
        // ==========================================================
        public static void ConfigurarSoloSeleccion(params ComboBox[] comboBoxes)
        {
            foreach (var cbo in comboBoxes)
            {
                if (cbo != null)
                {
                    cbo.DropDownStyle = ComboBoxStyle.DropDownList;
                }
            }
        }

        // ==========================================================
        // 3. SOLO NÚMEROS EN TEXTBOX
        // ==========================================================
        public static void PermitirSoloNumeros(params TextBox[] textBoxes)
        {
            foreach (var txt in textBoxes)
            {
                if (txt != null)
                {
                    txt.KeyPress -= SoloNumeros_KeyPress;
                    txt.KeyPress += SoloNumeros_KeyPress;
                }
            }
        }

        private static void SoloNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Solo permite números y la tecla de borrado (Backspace)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        // ==========================================================
        // 4. NAVEGACIÓN ENTRE CASILLAS CON LA TECLA ENTER
        // ==========================================================
        public static void ActivarNavegacionEnter(Form formulario)
        {
            formulario.KeyPreview = true;
            formulario.KeyDown -= Formulario_KeyDown;
            formulario.KeyDown += Formulario_KeyDown;
        }

        private static void Formulario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Form frm = sender as Form;

                // Si el control activo es un botón (ej: Guardar/Cancelar), permite su clic normal
                if (frm?.ActiveControl is Button) return;

                e.SuppressKeyPress = true; // Silencia el "beep" de Windows
                frm?.SelectNextControl(frm.ActiveControl, true, true, true, true);
            }
        }
    }
}
