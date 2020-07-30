using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiCaracterizacion.ModelsConsultasGenerales
{
    public class UsersAndForms
    {
        public string nombre { get; set; }
        public string apellido { get; set; }
        public int documento { get; set; }
        public string email { get; set; }
        public int rol { get; set; }
        public DateTime fecha_inicio { get; set; }
        public DateTime fecha_fin { get; set; }
        public string nombreCampana { get; set; }
        public int id_plantilla { get; set; }
        public string id_usuario { get; set; }
    }
}
