using System;

namespace WebApiCaracterizacion.ModelsConsultasGenerales
{
    public class FiltrarRegistrosExcel
    {
        public string valor_string { get; set; }
        public string valor_float { get; set; }
        public string valor_integer { get; set; }
        public string valor_date { get; set; }
        public DateTime fecha { get; set; }
        public int id_campo { get; set; }
        public string id_ficha { get; set; }

    }
}
