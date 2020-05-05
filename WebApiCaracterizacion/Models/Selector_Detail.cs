using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiCaracterizacion.Models
{
    public class Selector_Detail
    {
        public int id { get; set; }
        public string valor { get; set; }
        public string etiqueta { get; set; }
        public int? parent_value { get; set; }
        public int? parent_selector { get; set; }
        //Clave foranea para relacionar la tabla selector_detail con la tabla selectores
        [ForeignKey("Selector")]
        public int id_selector { get; set; }
        [JsonIgnore]
        public Selector Selector { get; set; }
    }
}