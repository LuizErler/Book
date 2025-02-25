using BookDomain.Entities;

namespace BookDomain.Services
{
    public interface IAutorService
    {
        Task<int> AdicionarAutorAsync(Autor autor);
        Task<bool> AtualizarAutorAsync(Autor autor);
        Task<bool> DeletarAutorAsync(int id);
        Task<Autor> ObterAutorPorIdAsync(int id);
        Task<IEnumerable<Autor>> ObterTodosAutoresAsync();
    }
}
