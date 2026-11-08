namespace CapaEntidad
{
    public class E_Extintor
    {
        public string id { get; set; }
        public string codigo_u { get; set; }
        public string codigo_cliente { get; set; } // <--- ASEGÚRATE DE TENER ESTA LÍNEA
        public string nro_serie { get; set; }
        public string nro_interno { get; set; }
        public string sede { get; set; }
        public string tipo { get; set; }
        public string capacidad { get; set; }
        public string marca { get; set; }
        public string anio_fabricacion { get; set; }
        public string eje_servicio { get; set; }
        public string proximo_mantenimiento { get; set; }
        public string fecha_prueba_hidrostatica { get; set; }
        public string vencimiento_ph { get; set; }
        public string estado { get; set; }
    }
}