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

        //Clave foranea para relacionar la tabla Formulario con la tabla Registro_Tablas
        [ForeignKey("Formulario")]
        public int id_formulario { get; set; }
        [JsonIgnore]
        public Formulario Formulario { get; set; }
    }
}
