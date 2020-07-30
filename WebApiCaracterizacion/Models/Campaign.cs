namespace WebApiCaracterizacion.Models
{
    public class Campaign
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string objetivo { get; set; }
        public string descripcion { get; set; }
        public string lider { get; set; }
        public string email_lider { get; set; }
        public string tel_lider { get; set; }
    }
}
