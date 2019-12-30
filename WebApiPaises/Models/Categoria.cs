using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace caracterizacion.Models
{
    public class Categoria
    {
        public Categoria()
        {
            Campos = new List<Campo>();
        }
        public int ID { get; set; }
        public int ID_Padre { get; set; }
        public int ID_Formulario { get; set; }
        [StringLength(80)]
        public string Nombre { get; set; }
        public int Orden { get; set; }
        public int Visible { get; set; }
        //Indicar que a cada categoria le corresponden un listado de campos
        public List<Campo> Campos { get; set; }

    }
}
