using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiCaracterizacion.Models
{
    public class Usuario
    {
        public string id { get; set; }
        [StringLength(80)]
        public string nombre { get; set; }
        [StringLength(80)]
        public string apellido { get; set; }
        public string email { get; set; }
        public string password { get; set; }
    }
}
