
using System.ComponentModel.DataAnnotations;

namespace Commander.Models
{
    public class Command
    {
        [Key]
        public int Id { get; set; }
        [Required]//es la forma de decirle que no puede ser nulo
        [MaxLength(250)]
        public string Como { get; set; }
        [Required]
        public string Linea { get; set; }
        [Required]
        public string Plataforma { get; set; }
    }
}