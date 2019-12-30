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
        public int ID { get; set; }
        [StringLength(80)]
        public string Nombre { get; set; }
        [StringLength(250)]
        public string Descripcion { get; set; }
        public int Valor_Maximo { get; set; }
        public int Valor_Minimo { get; set; }
        public int Valor_Defecto { get; set; }
        public int Orden { get; set; }
        public int Visible { get; set; }
        [StringLength(90)]
        public int Type { get; set; }
        public bool Disabled { get; set; }

        //Clave foranea para relacionar la tabla categoria con la tabla campo
        [ForeignKey("Categoria")]
        public int ID_Categoria { get; set; }
        [JsonIgnore]
        public Categoria Categoria { get; set; }
        //Clave foranea para relacionar la tabla plantilla con la tabla campo
        [ForeignKey("Plantilla")]
        public int ID_Plantilla { get; set; }
        [JsonIgnore]
        public Plantilla Plantilla { get; set; }

    }
}
