using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiCaracterizacion.Models
{
    public class Profesionales
    {
        public int id { get; set; }
        public int identificacion { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string telefono { get; set; }
        public string email { get; set; }
        public string profesion { get; set; }
        public string foto { get; set; }

    }
}
