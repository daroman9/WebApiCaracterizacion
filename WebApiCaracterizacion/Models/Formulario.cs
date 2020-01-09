using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WebApiCaracterizacion.Models;

namespace caracterizacion.Models
{
    public class Formulario
    {
        //Campos que comforman la tabla
        public int id { get; set; }
        public DateTime fecha_inicio { get; set; }
        public DateTime fecha_fin { get; set; }

        //Clave foranea para relacionar la tabla formularios con la tabla plantillas
        [ForeignKey("Plantilla")]
        public int id_plantilla { get; set; }
        [JsonIgnore]
        public Plantilla Plantilla { get; set; }
        //Clave foranea para relacionar la tabla formularios con la tabla usuarios
        [ForeignKey("Usuario")]
        public string id_usuario { get; set; }
        [JsonIgnore]
        public Usuario usuario { get; set; }
    }
}
