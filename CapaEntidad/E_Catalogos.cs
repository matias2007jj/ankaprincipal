using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class E_Catalogos
    {
        public class E_Sede
        {
            public int id { get; set; }
            public string nombre_sede { get; set; }
        }

        public class E_RespuestaSedes
        {
            public bool exito { get; set; }
            public List<E_Sede> sedes { get; set; }
        }
        public class E_TipoExtintor
        {
            public int id { get; set; }
            public string nombre { get; set; }
        }

        public class E_Capacidad
        {
            public int id { get; set; }
            public string valor { get; set; }
        }

        public class E_RespuestaCatalogos
        {
            public bool exito { get; set; }
            public List<E_TipoExtintor> tipos { get; set; }
            public List<E_Capacidad> capacidades { get; set; }
            public List<E_Marca> marcas { get; set; }
        }
        public class E_Marca
        {
            public int id { get; set; }
            public string nombre { get; set; }
        }
    }
}
