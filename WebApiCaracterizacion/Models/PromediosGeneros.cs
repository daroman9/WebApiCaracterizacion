using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiCaracterizacion.Models
{
    public class PromediosGeneros
    {
        public string genero { get; set; }
        public string municipio { get; set; }
        public int total { get; set; }
        public int cantidad { get; set; }
    }
}
