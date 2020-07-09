using caracterizacion.Models;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiCaracterizacion.Models
{
    public class Revision_Ajuste
    {
        public int id { get; set; }
        [ForeignKey("Ficha")]
        public string id_ficha { get; set; }
        [JsonIgnore]
        public Ficha Ficha { get; set; }
        public string estadoInicial { get; set; }
        public string estadoFinal { get; set; }
        public DateTime? date { get; set; }
        [ForeignKey("ApplicationUser")]
        public string id_usuario { get; set; }
        [JsonIgnore]
        public ApplicationUser ApplicationUser { get; set; }
    }
}
