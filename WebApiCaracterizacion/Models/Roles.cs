using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApiCaracterizacion.Models;

namespace WebApiCaracterizacion.Models
{
    public class Roles
    {
        public int id { get; set; }
        public string rol { get; set; }
    }
}
