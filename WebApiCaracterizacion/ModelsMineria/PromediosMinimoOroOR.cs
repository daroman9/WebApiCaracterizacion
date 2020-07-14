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
        public double promedio { get; set; }
        public int orden { get; set; }
        public string color { get; set; }
        public string nombre_campana { get; set; }
    }
}
