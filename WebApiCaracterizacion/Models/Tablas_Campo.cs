using caracterizacion.Models;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiCaracterizacion.Models
{
    public class Tablas_Campo
    {
        public int id { get; set; }
        [StringLength(250)]
        public string nombre { get; set; }
        [StringLength(100)]
        public string tipo { get; set; }
        public int? valor_maximo { get; set; }
        public int? valor_minimo { get; set; }
        public int? valor_defecto { get; set; }
        [StringLength(250)]
        public string rangos { get; set; }
        public int? orden { get; set; }
        public bool? visible { get; set; }
        public string unidad { get; set; }
        public string enableFields { get; set; }
        public string disableFields { get; set; }
        public bool? disabled { get; set; }

        //Clave foranea para relacionar la tabla Campo con la tabla Tablas_Campo
        [ForeignKey("Campo")]
        public int id_campo { get; set; }
        [JsonIgnore]
        public Campo Campo { get; set; }

        //Clave foranea para relacionar la tabla campos con la tabla selectores
        [ForeignKey("Selector")]
        public int? id_selector { get; set; }
        [JsonIgnore]
        public Selector Selector { get; set; }
        //Clave foranea para relacionar la tabla registros con la tabla validaciones
        [ForeignKey("Validacion")]
        public int? id_validacion { get; set; }
        [JsonIgnore]
        public Validacion Validacion { get; set; }
    }
}