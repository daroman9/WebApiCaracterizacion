using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiCaracterizacion.Models
{
    public class Permisos
    {
        public int id { get; set; }
        public string permiso { get; set; }
    }
}
