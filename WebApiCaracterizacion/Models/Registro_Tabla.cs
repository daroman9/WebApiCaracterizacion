using caracterizacion.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiCaracterizacion.Models
{
    public class Registro_Tabla
    {
        public int id { get; set; }
        public string value { get; set; }

        //Clave foranea para relacionar la tabla Registro_Tablas con la tabla formularios
        [ForeignKey("Formulario")]
        public int id_formulario { get; set; }
        [JsonIgnore]
       public Formulario Formulario { get; set; }
    }
}
