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
        //Clave foranea para relacionar la tabla formularios con la tabla plantillas
        [ForeignKey("Plantilla")]
        public int id_plantilla { get; set; }
        [JsonIgnore]
        public Plantilla Plantilla { get; set; }

        //Clave foranea para relacionar la tabla formularios con la tabla usuarios
        [ForeignKey("ApplicationUser")]
        public string id_usuario { get; set; }
        [JsonIgnore]
        public ApplicationUser ApplicationUser { get; set; }

        //Clave foranea para relacionar la tabla formularios con la tabla campaign
        [ForeignKey("Campaign")]
        public int id_campaign { get; set; }
        [JsonIgnore]
        public Campaign Campaign { get; set; }
    }
}