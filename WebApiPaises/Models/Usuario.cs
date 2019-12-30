using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiCaracterizacion.Models
{
    public class Usuario
    {
        public int ID { get; set; }
        [StringLength(80)]
        public string Nombre { get; set; }
        [StringLength(80)]
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
