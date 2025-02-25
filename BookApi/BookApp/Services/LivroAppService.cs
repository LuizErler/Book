using BookDomain.Entities;
using BookDomain.Services;

namespace BookApp.Services
{
    public class LivroAppService : ILivroAppService
    {
        private readonly ILivroService _livroService;

        public LivroAppService(ILivroService livroService)
        {
            _livroService = livroService;
        }

        public async Task<int> AdicionarAsync(Livro livro)
        {
            return await _livroService.AdicionarAsync(livro);
        }

        public async Task<bool> AtualizarAsync(Livro livro)
        {
            return await _livroService.AtualizarAsync(livro);
        }

        public async Task<bool> DeletarAsync(int id)
        {
            return await _livroService.DeletarAsync(id);
        }

        public async Task<Livro?> ObterPorIdAsync(int id)
        {
            return await _livroService.ObterPorIdAsync(id);
        }

        public async Task<IEnumerable<Livro>> ObterTodosAsync()
        {
            return await _livroService.ObterTodosAsync();
        }
    }
}
