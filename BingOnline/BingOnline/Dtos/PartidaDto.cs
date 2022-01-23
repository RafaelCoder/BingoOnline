namespace BingOnline.Dtos
{
    public class PartidaDto
    {
        public Guid Id { get; set; }
        public Guid IdUsuarioCriador { get; set; }
        public DateTime dt { get; set; }
        public bool Finalizado { get; set; } = false;
        public List<ParticipanteDto> Participantes { get; set; } = null;
        public List<int> NumerosSorteados { get; set; } = new List<int>();
    }
}
