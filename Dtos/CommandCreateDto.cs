using System.ComponentModel.DataAnnotations;

namespace Commander.Dtos
{
    public class CommandCreateDto
    {
        
        //public int Id { get; set; } - No se le pasa el ID porque ya se encarga la BD de crearlo
        [Required]
        public string Como { get; set; }
        [Required]
        public string Linea { get; set; }
        [Required]
        public string Plataforma { get; set; }
    }
}