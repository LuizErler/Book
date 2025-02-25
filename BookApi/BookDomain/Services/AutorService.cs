using BookDomain.Entities;
using BookDomain.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookDomain.Services
{
    public class AutorService : IAutorService
    {
        private readonly IAutorRepository _autorRepository;

        public AutorService(IAutorRepository autorRepository)
        {
            _autorRepository = autorRepository;
        }

        public async Task<int> AdicionarAutorAsync(Autor autor)
        {
            return await _autorRepository.AdicionarAsync(autor);
        }

        public async Task<bool> AtualizarAutorAsync(Autor autor)
        {
            return await _autorRepository.AtualizarAsync(autor);
        }

        public async Task<bool> DeletarAutorAsync(int id)
        {
            return await _autorRepository.DeletarAsync(id);
        }

        public async Task<Autor> ObterAutorPorIdAsync(int id)
        {
            return await _autorRepository.ObterPorIdAsync(id);
        }

        public async Task<IEnumerable<Autor>> ObterTodosAutoresAsync()
        {
            return await _autorRepository.ObterTodosAsync();
        }
    }
}
