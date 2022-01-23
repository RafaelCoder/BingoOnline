namespace BingOnline.Persistencia.Modelo
{
    public class Participante
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Usuario Usuario { get; set; }
        public Cartela Cartela { get; set; }
    }
}
