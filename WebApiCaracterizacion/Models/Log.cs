using caracterizacion.Models;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations.Schema;


namespace WebApiCaracterizacion.Models
{
    public class Log
    {
        public int id { get; set; }
        public DateTime? date { get; set; }
        public string estadoInicial { get; set; }
        public string estadoFinal { get; set; }

        public string camposCambiado { get; set; }

        public string valorAnterior { get; set; }

        public string valorNuevo { get; set; }

        public int noConformidades { get; set; }

        //Claves foraneas
        [ForeignKey("ApplicationUser")]
        public string id_usuario { get; set; }
        [JsonIgnore]
        public ApplicationUser ApplicationUser { get; set; }

        [ForeignKey("Ficha")]
        public string id_ficha { get; set; }
        [JsonIgnore]
        public Ficha Ficha { get; set; }

    }
}
