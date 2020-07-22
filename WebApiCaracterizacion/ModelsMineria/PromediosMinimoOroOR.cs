using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiCaracterizacion.ModelsMineria
{
    public class PromediosMinimoOroOR
    {
        public string tipo_plantilla { get; set; }
        public string municipio { get; set; }
        public string dato { get; set; }
        public decimal promedio { get; set; }
        public double orden { get; set; }
        public string color { get; set; }
        public string nombre_campana { get; set; }
    }
}
