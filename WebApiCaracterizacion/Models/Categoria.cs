using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace caracterizacion.Models
{
    public class Categoria
    {
        public int id { get; set; }
        public int id_padre { get; set; }
        [StringLength(80)]
        public string nombre { get; set; }
        public int orden { get; set; }
        public int visible { get; set; }
        [StringLength(7)]
        public string color { get; set; }
        public string image { get; set; }
    }
}