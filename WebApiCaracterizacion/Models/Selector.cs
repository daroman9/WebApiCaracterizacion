using caracterizacion.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiCaracterizacion.Models
{
    public class Selector
    {
        public int id { get; set; }
        public int id_padre { get; set; }
        [StringLength(80)]
        public string nombre { get; set; }
        public int value { get; set; }
        public int orden { get; set; }
        public bool visible { get; set; }

        //Clave foranea para relacionar la tabla Campo con la tabla Selector
        [ForeignKey("Campo")]
        public int id_campo { get; set; }
        [JsonIgnore]
        public Campo Campo { get; set; }

    }
}
