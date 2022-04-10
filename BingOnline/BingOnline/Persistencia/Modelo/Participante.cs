namespace BingOnline.Persistencia.Modelo
{
    public class Participante
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid IdUsuario { get; set; }
        public Cartela Cartela { get; set; }
    }
}
