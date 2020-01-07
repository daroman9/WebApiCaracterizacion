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
    public class Campo
    {
        //Campos que se muestran en los formularios
        public int id { get; set; }
        [StringLength(80)]
        public string nombre { get; set; }
        [StringLength(250)]
        public string descripcion { get; set; }
        public int? valor_maximo { get; set; }
        public int? valor_minimo { get; set; }
        public int? valor_defecto { get; set; }
        public string rangos { get; set; }
        public int? orden { get; set; }
        public int? visible { get; set; }
        public string tipo { get; set; }
        public int? required { get; set; }
        public string unidad { get; set; }
        public int? disabled { get; set; }

        //Clave foranea para relacionar la tabla categoria con la tabla campo
        [ForeignKey("Categoria")]
        public int id_categoria { get; set; }
        [JsonIgnore]
        public Categoria Categoria { get; set; }
        //Clave foranea para relacionar la tabla plantilla con la tabla campo
        [ForeignKey("Plantilla")]
        public int id_plantilla { get; set; }
        [JsonIgnore]
        public Plantilla Plantilla { get; set; }

    }
}
