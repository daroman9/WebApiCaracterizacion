using System.ComponentModel.DataAnnotations;

namespace WebApiCaracterizacion.Models
{
    public class Recovery
    {
        [EmailAddress]
        [Required]
        public string Email { get; set; }
    }
}
