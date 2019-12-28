using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace caracterizacion.Models
{
    public class Formato
    {
        //Campos que comforman la tabla
        public int Id { get; set; }
        public string Value { get; set; }


        //Clave foranea para relacionar los fotmatos con la tabla de campos
        [ForeignKey("Campo")]
        public int CampoId { get; set; }
        [JsonIgnore]
        public Campo Campo { get; set; }
    }
}
