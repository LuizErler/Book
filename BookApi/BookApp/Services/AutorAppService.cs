using BookDomain.Entities;
using BookDomain.Services;

namespace BookApp.Services
{
    public class AutorAppService : IAutorAppService
    {
        private readonly IAutorService _autorService;

        public AutorAppService(IAutorService autorService)
        {
            _autorService = autorService;
        }

        public async Task<int> AdicionarAutorAsync(Autor autor)
        {
            return await _autorService.AdicionarAutorAsync(autor);
        }

        public async Task<bool> AtualizarAutorAsync(Autor autor)
        {
            return await _autorService.AtualizarAutorAsync(autor);
        }

        public async Task<bool> DeletarAutorAsync(int id)
        {
            return await _autorService.DeletarAutorAsync(id);
        }

        public async Task<Autor> ObterAutorPorIdAsync(int id)
        {
            return await _autorService.ObterAutorPorIdAsync(id);
        }

        public async Task<IEnumerable<Autor>> ObterTodosAutoresAsync()
        {
            return await _autorService.ObterTodosAutoresAsync();
        }
    }
}
