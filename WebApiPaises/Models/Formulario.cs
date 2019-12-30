using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WebApiCaracterizacion.Models;

namespace caracterizacion.Models
{
    public class Formulario
    {
        //Campos que comforman la tabla
        public int ID { get; set; }
        public int ID_Usuario { get; set; }
        public DateTime Fecha_Inicio { get; set; }
        public DateTime Fecha_Fin { get; set; }

        //Clave foranea para relacionar la tabla plantilla con la tabla formulario
        [ForeignKey("Plantilla")]
        public int ID_Plantilla { get; set; }
        [JsonIgnore]
        public Plantilla Plantilla { get; set; }
    }
}
