using BookDomain.Entities;

namespace BookApp.Services
{
    public interface IAutorAppService
    {
        Task<int> AdicionarAutorAsync(Autor autor);
        Task<bool> AtualizarAutorAsync(Autor autor);
        Task<bool> DeletarAutorAsync(int id);
        Task<Autor> ObterAutorPorIdAsync(int id);
        Task<IEnumerable<Autor>> ObterTodosAutoresAsync();
    }
}
