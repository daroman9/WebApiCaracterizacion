using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiCaracterizacion.Models
{
    public class ApplicationUser : IdentityUser
    {
        [StringLength(250)]
        public string Nombre { get; set; }
        [StringLength(250)]
        public string Apellido { get; set; }
        public int Documento { get; set; }
        public string Password { get; set; }

        //Clave foranea para relacionar la tabla categorias con la tabla plantillas
        [ForeignKey("Roles")]
        public int id_rol { get; set; }
        [JsonIgnore]
        public Roles roles { get; set; }
    }
}