using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiCaracterizacion.Models
{
    public class Entidad
    {
        public int id { get; set; }
        public int identificacion { get; set; }
        public string nombre { get; set; }
        public string direccion { get; set; }
        public string contacto { get; set; }
        public string telContacto { get; set; }
        public string emailContacto { get; set; }
        public string grupoInvestigacion { get; set; }
    }
}
