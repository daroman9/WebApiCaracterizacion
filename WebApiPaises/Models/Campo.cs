using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace caracterizacion.Models
{
    public class Campo
    {
        //Campos que se muestran en los formularios
        public int Id { get; set; }
        public string Nombre { get; set; }




        //Clave foranea para relacionar los campos con las categorias
        [ForeignKey("Categoria")]
        public int CategoriaId { get; set; }
        [JsonIgnore]
        public Categoria Categoria { get; set; }




    }
}
