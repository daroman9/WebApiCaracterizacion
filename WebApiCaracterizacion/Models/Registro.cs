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
        public int id { get; set; }
        public string valor_string { get; set; }
        public float valor_float { get; set; }
        public int valor_integer { get; set; }
        public DateTime  valor_date { get; set; }
        public DateTime fecha { get; set; }

        //Clave foranea para relacionar la tabla registro con la tabla campo
        [ForeignKey("Campo")]
        public int id_campo { get; set; }
        [JsonIgnore]
        public Campo Campo { get; set; }

    }
}
