using BingOnline.Types;

namespace BingOnline.Persistencia.Modelo
{
    public class Partida
    {
        public Guid Id { get; set; }
        public Guid IdUsuarioCriador { get; set; }
        public DateTime dt { get; set; } = DateTime.Now;
        public Status Situacao { get; set; } = Status.Created;
        public IList<Participante> Participantes { get; set; } = new List<Participante>();
        public IList<int> NumerosSorteados { get; set; } = new List<int>();
    }
}
