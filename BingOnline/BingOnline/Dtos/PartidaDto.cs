namespace BingOnline.Dtos
{
    public class PartidaDto
    {
        public Guid Id { get; set; }
        public Guid IdUsuarioCriador { get; set; }
        public DateTime dt { get; set; }
        public bool Finalizado { get; set; } = false;
        //public List<Participante> Participantes { get; set; } = new List<Participante>();
        public List<int> NumerosSorteados { get; set; } = new List<int>();
    }
}
