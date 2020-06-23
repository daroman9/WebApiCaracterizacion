using caracterizacion.Models;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiCaracterizacion.Models
{
    public class Registro_Tabla
    {
        public int id { get; set; }
        public string valor_string{ get; set; }
        public float? valor_float { get; set; }
        public int? valor_integer { get; set; }
       
        public DateTime? valor_date { get; set; }
        public DateTime? fecha { get; set; }
        public string id_column { get; set; }
        public string row { get; set; }


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