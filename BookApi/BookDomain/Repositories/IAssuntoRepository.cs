using BookDomain.Entities;

namespace BookDomain.Repositories
{
    public interface IAssuntoRepository
    {
        Task<int> AdicionarAssuntoAsync(Assunto assunto);
        Task<bool> AtualizarAssuntoAsync(Assunto assunto);
        Task<bool> DeletarAssuntoAsync(int id);
        Task<Assunto> ObterAssuntoPorIdAsync(int id);
        Task<IEnumerable<Assunto>> ObterTodosAssuntosAsync();
        Task<IEnumerable<LivroAssunto>> ObterLivroAssuntoPorIdAsync(int id);
        Task<bool> DeletarLivroAssuntoAsync(int id);
        Task AdicionarLivroAssuntoAsync(int CodLivro, int CodAssunto);
    }
}
