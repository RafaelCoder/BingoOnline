using BingOnline.Persistencia.Modelo;

namespace BingOnline.Persistencia.Repositorios.Interfaces
{
    public interface IUsuarioRepositorio
    {
        Task Adicionar(Usuario usuario);
        Task<Usuario> Obter(Guid id);
        Task<Usuario> ObterPorNome(string nome);
        Task Atualizar(Usuario usuario);
        Task Deletar(Usuario usuario);
        Task<IEnumerable<Usuario>> ObterTodos();
    }
}
