using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WebApiCaracterizacion.Models;

namespace caracterizacion.Models
{
    public class Categoria
    {
        public int id { get; set; }
        public int? id_padre { get; set; }
        [StringLength(250)]
        public string nombre { get; set; }
        public int? orden { get; set; }
        public bool? visible { get; set; }
        [StringLength(20)]
        public string color { get; set; }
        public string image { get; set; }

        //Clave foranea para relacionar la tabla categorias con la tabla plantillas
        [ForeignKey("Plantilla")]
        public int id_plantilla { get; set; }
        [JsonIgnore]
        public Plantilla plantilla { get; set; }
    }
}