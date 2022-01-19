using BingOnline.Persistencia.Modelo;

namespace BingOnline.Persistencia.Repositorios.Interfaces
{
    public interface IPartidaRepositorio
    {
        Task Adicionar(Partida partida);
        Task<Partida> Obter(Guid id);
        Task Atualizar(Partida partida);
        Task Deletar(Partida partida);
        Task<IEnumerable<Partida>> ObterTodos();
    }
}
