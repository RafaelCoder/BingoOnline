namespace BingOnline.Persistencia.Modelo
{
    public class Participante
    {
        public int Id { get; set; }
        public Usuario Usuario { get; set; }
        public Cartela Cartela { get; set; }
    }
}
