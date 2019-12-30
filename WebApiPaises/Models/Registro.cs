using caracterizacion.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiCaracterizacion.Models
{
    public class Registro
    {
        public int ID { get; set; }
        public string Valor_String { get; set; }
        public float Valor_Float { get; set; }
        public int Valor_Integer { get; set; }
        public DateTime Valor_Date { get; set; }
        public DateTime Fecha { get; set; }

        //Clave foranea para relacionar la tabla registro con la tabla campo
        [ForeignKey("Campo")]
        public int ID_Campo { get; set; }
        [JsonIgnore]
        public Campo Campo { get; set; }

    }
}
