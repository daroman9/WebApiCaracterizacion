namespace WebApiCaracterizacion.ModelsTransporte
{
    public class PromediosMesesActividadGN
    {
        public string municipio { get; set; }
        public string detalle { get; set; }
        public string dato { get; set; }
        public int cantidad_si { get; set; }
        public double porcentaje_si { get; set; }
        public int cantidad_no { get; set; }
        public double porcentaje_no { get; set; }
        public double orden { get; set; }
        public string color { get; set; }
        public string nombre_campana { get; set; }
    }
}
