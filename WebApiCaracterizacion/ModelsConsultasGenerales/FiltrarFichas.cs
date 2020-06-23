using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiCaracterizacion.ModelsConsultasGenerales
{
    public class FiltrarFichas
    {
        public DateTime fecha_ficha { get; set; }
        public string nombre_aspecto { get; set; }
        public string codigo_ficha { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string email { get; set; }   
        public string nombre_campana { get; set; }
        public string id_ficha { get; set; }
        public int estado { get; set; }

    }
}
