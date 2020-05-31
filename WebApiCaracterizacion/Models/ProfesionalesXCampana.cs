using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiCaracterizacion.Models
{
    public class ProfesionalesXCampana
    {
        public int id { get; set; }

        //Clave foranea para relacionar la ProfesionalesXCamapana con la tabla EntidadesXCampana
        [ForeignKey("EntidadesXCampana")]
        public int id_entidad { get; set; }
        [JsonIgnore]
        public EntidadesXCampana EntidadesXCampana { get; set; }
        //Clave foranea para relacionar la tabla ProfesionalesXCamapana con la tabla usuarios
        [ForeignKey("ApplicationUser")]
        public string id_usuario { get; set; }
        [JsonIgnore]
        public ApplicationUser ApplicationUser { get; set; }

    }
}
