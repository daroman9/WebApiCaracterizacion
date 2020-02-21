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
        public string valor_string{ get; set; }
        public float valor_float { get; set; }
        public int valor_integer { get; set; }
        public DateTime valor_date { get; set; }
        public int id_column { get; set; }
        public int row { get; set; }


        [ForeignKey("Tablas_Campo")]
        public int id_registro_tabla_campo { get; set; }
        [JsonIgnore]
        public Tablas_Campo Tablas_Campo { get; set; }
        [ForeignKey("Campo")]
        public int id_campo { get; set; }
        [JsonIgnore]
        public Campo Campo { get; set; }
        //Clave foranea para relacionar la tabla registros con la tabla fichas
        [ForeignKey("Ficha")]
        public string id_ficha { get; set; }
        [JsonIgnore]
        public Ficha Ficha { get; set; }
    }
}