using BookDomain.Entities;

namespace BookApp.Services
{
    public interface ILivroAppService
    {
        Task<int> AdicionarAsync(Livro livro);
        Task<bool> AtualizarAsync(Livro livro);
        Task<bool> DeletarAsync(int id);
        Task<Livro?> ObterPorIdAsync(int id);
        Task<IEnumerable<Livro>> ObterTodosAsync();
    }
}
