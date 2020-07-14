namespace WebApiCaracterizacion.ModelsGanaderia
{
    public class PromediosMesesCarneGN
    {
        public string tipo_plantilla { get; set; }
        public string municipio { get; set; }
        public string dato { get; set; }
        public int cantidad_si { get; set; }
        public double porcentaje_si { get; set; }
        public int cantidad_no { get; set; }
        public double porcentaje_no { get; set; }
        public int orden { get; set; }
        public string color { get; set; }
        public string nombre_campana { get; set; }
    }
}
