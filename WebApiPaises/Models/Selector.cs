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
        public int ID { get; set; }
        public int ID_Padre { get; set; }
        [StringLength(80)]
        public string Nombre { get; set; }
        public int Value { get; set; }
        public int Orden { get; set; }
        public bool Visible { get; set; }

        //Clave foranea para relacionar la tabla Campo con la tabla Selector
        [ForeignKey("Campo")]
        public int ID_Campo { get; set; }
        [JsonIgnore]
        public Campo Campo { get; set; }

    }
}
