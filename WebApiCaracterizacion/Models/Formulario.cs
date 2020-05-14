using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using WebApiCaracterizacion.Models;

namespace caracterizacion.Models
{
    public class Formulario
    {
  
        public int id { get; set; }
        public DateTime? fecha_inicio { get; set; }
        public DateTime? fecha_fin { get; set; }
        public string nombreCampaña { get; set;}
        public string objetivo { get; set; }
        public string descripcion { get; set; }
        public string lider { get; set; }
        public string emailLider { get; set; }
        public string telefonoLider { get; set; }

        //Clave foranea para relacionar la tabla formularios con la tabla plantillas
        [ForeignKey("Plantilla")]
        public int id_plantilla { get; set; }
        [JsonIgnore]
        public Plantilla Plantilla { get; set; }
        //Clave foranea para relacionar la tabla formularios con la tabla usuarios
        [ForeignKey("ApplicationUser")]
        public string id_usuario { get; set; }
        [JsonIgnore]
        public ApplicationUser applicationUser { get; set; }
    }
}