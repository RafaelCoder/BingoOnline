using System.ComponentModel.DataAnnotations;

namespace BingOnline.Dtos
{
    public class CreateParticipanteDto
    {
        [Required]
        public Guid IdUsuario { get; set; }
    }
}
