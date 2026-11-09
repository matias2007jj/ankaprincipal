using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class E_HistorialServicio
    {
        public int id { get; set; }
        public int id_extintor { get; set; }
        public string codigo_u { get; set; }
        public string tipo_servicio { get; set; }
        public string descripcion { get; set; }
        public string observaciones { get; set; }
        public string ruta_foto { get; set; }
        public string fecha_servicio { get; set; }
    }
}
