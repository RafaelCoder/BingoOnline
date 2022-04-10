using BingOnline.Types;

namespace BingOnline.Dtos
{
    public class PartidaDto
    {
        public Guid Id { get; set; }
        public Guid IdUsuarioCriador { get; set; }
        public DateTime dt { get; set; }
        public Status Situacao { get; set; } = Status.Created;
        public IList<ParticipanteDto> Participantes { get; set; } = null;
        public IList<int> NumerosSorteados { get; set; } = new List<int>();
    }
}
