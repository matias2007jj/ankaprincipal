namespace CapaEntidad
{
    public class E_Extintor
    {
        public int id { get; set; }
        public string codigo_u { get; set; }
        public string codigo_cliente { get; set; }
        public string nombre_cliente { get; set; } // Nombre o Razón Social del cliente
        public string sede { get; set; }
        public string nro_serie { get; set; }
        public string tipo { get; set; }
        public string capacidad { get; set; } // Capacidad del extintor
        public string marca { get; set; }
        public string nro_interno { get; set; }
 
        public string ubicacion { get; set; }     // Para la columna Ubicación
        public string anio_fabricacion { get; set; }
        public string eje_servicio { get; set; }
        public string proximo_mantenimiento { get; set; }
        public string fecha_prueba_hidrostatica { get; set; }
        public string vencimiento_ph { get; set; }
        public string estado { get; set; }
        public string numero_certificado { get; set; }

        public string nro_certificado { get; set; }
        public string ruta_cert_operatividad { get; set; }
        public string ruta_informe_tecnico { get; set; }
        public string ruta_cert_ph { get; set; }
    }
}