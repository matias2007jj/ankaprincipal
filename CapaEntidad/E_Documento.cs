using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class E_Documento
    {
        public string tipo_documento { get; set; } // Ej: "Certificado de Operatividad", "Informe Técnico", "Certificado PH"
        public string nombre_archivo { get; set; } // Ej: "documento_123.pdf"
        public string ruta_local { get; set; }     // Ruta en la PC del usuario (C:\...)
        public string ruta_web { get; set; }
    }
}
