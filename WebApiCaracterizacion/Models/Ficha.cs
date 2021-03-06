﻿using caracterizacion.Models;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiCaracterizacion.Models
{
    public class Ficha
    {
        public string id { get; set; }
        public string latitud { get; set; }
        public string longitud { get; set; }
        public DateTime? date { get; set; }

        //Claves foraneas
        [ForeignKey("ApplicationUser")]
        public string id_usuario { get; set; }
        [JsonIgnore]
        public ApplicationUser ApplicationUser { get; set; }
        [ForeignKey("Formulario")]
        public int id_formulario { get; set; }
        [JsonIgnore]
        public Formulario Formulario { get; set; }
        [ForeignKey("Plantilla")]
        public int id_plantilla { get; set; }
        [JsonIgnore]
        public Plantilla Plantilla { get; set; }

        public int estado { get; set; }

    }
}