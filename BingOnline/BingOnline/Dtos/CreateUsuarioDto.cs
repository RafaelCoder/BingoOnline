using System.ComponentModel.DataAnnotations;

namespace BingOnline.Dtos
{
    public class CreateUsuarioDto
    {
        [Required]
        [MinLength(4)]
        [MaxLength(100)]
        public string Nome { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MinLength(5)]
        public string Senha { get; set; }
    }
}
