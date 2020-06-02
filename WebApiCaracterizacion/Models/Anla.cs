using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiCaracterizacion.Models
{
    public class Anla
    {
        public int id { get; set; }
        public double coor_este { get; set; }
        public double coor_norte { get; set; }
        public string expediente { get; set; }
        public string operador { get; set; }
        public string proyecto { get; set; }
        public string contrato { get; set; }
        public string codigo { get; set; }
        public string car { get; set; }
        public string observacion { get; set; }
    }
}
