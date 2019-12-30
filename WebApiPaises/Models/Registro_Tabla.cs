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
        public int ID { get; set; }
        public string Value { get; set; }

        //Clave foranea para relacionar la tabla Formulario con la tabla Registro_Tablas
        [ForeignKey("Formulario")]
        public int ID_Formulario { get; set; }
        [JsonIgnore]
        public Formulario Formulario { get; set; }
    }
}
