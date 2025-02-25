using BookDomain.Entities;
using BookDomain.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookDomain.Services
{
    public class AssuntoService : IAssuntoService
    {
        private readonly IAssuntoRepository _assuntoRepository;

        public AssuntoService(IAssuntoRepository assuntoRepository)
        {
            _assuntoRepository = assuntoRepository;
        }

        public async Task<int> AdicionarAssuntoAsync(Assunto assunto)
        {
            return await _assuntoRepository.AdicionarAssuntoAsync(assunto);
        }

        public async Task<bool> AtualizarAssuntoAsync(Assunto assunto)
        {
            return await _assuntoRepository.AtualizarAssuntoAsync(assunto);
        }

        public async Task<bool> DeletarAssuntoAsync(int id)
        {
            return await _assuntoRepository.DeletarAssuntoAsync(id);
        }

        public async Task<Assunto> ObterAssuntoPorIdAsync(int id)
        {
            return await _assuntoRepository.ObterAssuntoPorIdAsync(id);
        }

        public async Task<IEnumerable<Assunto>> ObterTodosAssuntosAsync()
        {
            return await _assuntoRepository.ObterTodosAssuntosAsync();
        }
    }
}
