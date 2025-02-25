using BookDomain.Entities;

namespace BookDomain.Repositories
{
    public interface ILivroRepository
    {
        Task<int> AdicionarAsync(Livro livro);
        Task<bool> AtualizarAsync(Livro livro);
        Task<bool> DeletarAsync(int id);
        Task<Livro?> ObterPorIdAsync(int id);
        Task<IEnumerable<Livro>> ObterTodosAsync();
    }
}
