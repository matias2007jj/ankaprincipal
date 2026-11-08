using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class E_Cliente
    {
        public int id { get; set; }
        public string codigo_cliente { get; set; }
        public string razon_social { get; set; }
        public string nombre_comercial { get; set; }
        public string ruc { get; set; }
        public string direccion { get; set; }
        public string provincia { get; set; }
        public string contacto { get; set; }
        public string cargo { get; set; }
        public string correo { get; set; }
        public string telefono { get; set; }
        public string forma_pago { get; set; }
        public string moneda { get; set; }
        public string ejecutivo_asignado { get; set; }
        public string estado { get; set; }
    }
}
