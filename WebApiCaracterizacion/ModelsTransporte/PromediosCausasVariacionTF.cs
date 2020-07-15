using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiCaracterizacion.ModelsTransporte
{
    public class PromediosCausasVariacionTF
    {
        public string municipio { get; set; }
        public string dato { get; set; }
        public int cantidad { get; set; }
        public double porcentaje { get; set; }
        public double orden { get; set; }
        public string color { get; set; }
        public string nombre_campana { get; set; }
    }
}
