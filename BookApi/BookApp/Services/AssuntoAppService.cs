using BookDomain.Entities;
using BookDomain.Services;

namespace BookApp.Services
{
    public class AssuntoAppService : IAssuntoAppService
    {
        private readonly IAssuntoService _assuntoService;

        public AssuntoAppService(IAssuntoService assuntoService)
        {
            _assuntoService = assuntoService;
        }

        public async Task<int> AdicionarAssuntoAsync(Assunto assunto)
        {
            return await _assuntoService.AdicionarAssuntoAsync(assunto);
        }

        public async Task<bool> AtualizarAssuntoAsync(Assunto assunto)
        {
            return await _assuntoService.AtualizarAssuntoAsync(assunto);
        }

        public async Task<bool> DeletarAssuntoAsync(int id)
        {
            return await _assuntoService.DeletarAssuntoAsync(id);
        }

        public async Task<Assunto> ObterAssuntoPorIdAsync(int id)
        {
            return await _assuntoService.ObterAssuntoPorIdAsync(id);
        }

        public async Task<IEnumerable<Assunto>> ObterTodosAssuntosAsync()
        {
            return await _assuntoService.ObterTodosAssuntosAsync();
        }
    }
}
