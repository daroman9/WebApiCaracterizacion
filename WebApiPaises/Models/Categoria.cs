using System;
using System.Collections.Generic;
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
        public int Id { get; set; }
        public string Nombre { get; set; }
        //Indicar que a cada categoria le corresponden un listado de campos
        public List<Campo> Campos { get; set; }

    }
}
