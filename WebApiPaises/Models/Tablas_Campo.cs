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
    public class Tablas_Campo
    {
        public int ID { get; set; }
        [StringLength(80)]
        public string Nombre { get; set; }
        [StringLength(80)]
        public string Tipo { get; set; }

        //Clave foranea para relacionar la tabla Campo con la tabla Tablas_Campo
        [ForeignKey("Campo")]
        public int ID_Campo { get; set; }
        [JsonIgnore]
        public Campo Campo { get; set; }
    }
}
