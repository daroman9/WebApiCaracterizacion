using caracterizacion.Models;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiCaracterizacion.Models
{
    public class EntidadesXCampana
    {
        public int id { get; set; }
        public string contrato { get; set; }

        //Clave foranea para relacionar la tabla campos con la tabla Entidad
        [ForeignKey("Entidad")]
        public int id_entidad { get; set; }
        [JsonIgnore]
        public Entidad Entidad { get; set; }
        //Clave foranea para relacionar la tabla campos con la tabla Formularios
        [ForeignKey("Formulario")]
        public int id_formulario { get; set; }
        [JsonIgnore]
        public Formulario Formulario { get; set; }
    }
}
