﻿using caracterizacion.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiCaracterizacion.Models
{
    public class Tablas_Campo
    {
        public int id { get; set; }
        [StringLength(250)]
        public string nombre { get; set; }
        [StringLength(100)]
        public string tipo { get; set; }
        public int valor_maximo { get; set; }
        public int valor_minimo { get; set; }
        public int valor_defecto { get; set; }
        [StringLength(250)]
        public string rangos { get; set; }
        public int orden { get; set; }
        public bool visible { get; set; }
        public string unidad { get; set; }
        public bool disabled { get; set; }

        //Clave foranea para relacionar la tabla Campo con la tabla Tablas_Campo
        [ForeignKey("Campo")]
        public int id_campo { get; set; }
        [JsonIgnore]
        public Campo Campo { get; set; }
    }
}