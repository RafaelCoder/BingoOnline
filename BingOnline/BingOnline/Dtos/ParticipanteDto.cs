namespace BingOnline.Dtos
{
    public class ParticipanteDto
    {
        public Guid Id { get; set; }
        public UsuarioDto Usuario { get; set; } // Criar um usuário especifico para exibição  UsuarioExibicaoDto
        public CartelaDto Cartela { get; set; }
    }
}
