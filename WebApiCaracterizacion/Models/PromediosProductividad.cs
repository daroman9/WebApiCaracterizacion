using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiCaracterizacion.Models
{
    public class PromediosProductividad
    {
        public string variacion { get; set; }
        public int cantidad { get; set; }
        public string aspecto { get; set; }
        public string municipio { get; set; }
    }
}
