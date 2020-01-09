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
        [StringLength(250)]
        public string nombre { get; set; }
        [StringLength(250)]
        public string descripcion { get; set; }
        public int? valor_maximo { get; set; }
        public int? valor_minimo { get; set; }
        public int? valor_defecto { get; set; }
        public string rangos { get; set; }
        public int? orden { get; set; }
        public bool? visible { get; set; }
        public string tipo { get; set; }
        public bool? required { get; set; }
        public string unidad { get; set; }
        public bool? disabled { get; set; }
        public string enableCategories { get; set; }
        public string enableFields { get; set; }
        public string disableCategories { get; set; }
        public string disableFields { get; set; }
      
        //Clave foranea para relacionar la tabla campos con la tabla categorias
        [ForeignKey("Categoria")]
        public int id_categoria { get; set; }
        [JsonIgnore]
        public Categoria Categoria { get; set; }
        //Clave foranea para relacionar la tabla campos con la tabla plantillas
        [ForeignKey("Plantilla")]
        public int id_plantilla { get; set; }
        [JsonIgnore]
        public Plantilla Plantilla { get; set; }
        //Clave foranea para relacionar la tabla campos con la tabla selectores
        [ForeignKey("Selector")]
        public int? id_selector { get; set; }
        [JsonIgnore]
        public Selector selector { get; set; }



    }
}
