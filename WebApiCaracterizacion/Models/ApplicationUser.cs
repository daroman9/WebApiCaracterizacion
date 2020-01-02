using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace WebApiCaracterizacion.Models
{
    public class ApplicationUser : IdentityUser
    {
        [StringLength(80)]
        public string Nombre { get; set; }
        [StringLength(80)]
        public string Apellido { get; set; }
    }
}