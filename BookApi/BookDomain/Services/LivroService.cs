using BookDomain.Entities;
using BookDomain.Repositories;

namespace BookDomain.Services
{
    public class LivroService : ILivroService
    {
        private readonly ILivroRepository _livroRepository;

        public LivroService(ILivroRepository livroRepository)
        {
            _livroRepository = livroRepository;
        }

        public async Task<int> AdicionarAsync(Livro livro)
        {
            if (string.IsNullOrWhiteSpace(livro.Titulo))
                throw new ArgumentException("O título do livro não pode ser vazio.");

            if (livro.Edicao < 1)
                throw new ArgumentException("A edição do livro deve ser maior que 0.");

            return await _livroRepository.AdicionarAsync(livro);
        }

        public async Task<bool> AtualizarAsync(Livro livro)
        {
            var livroExistente = await _livroRepository.ObterPorIdAsync(livro.Codl);
            if (livroExistente == null)
                throw new KeyNotFoundException("Livro não encontrado.");

            return await _livroRepository.AtualizarAsync(livro);
        }

        public async Task<bool> DeletarAsync(int id)
        {
            var livroExistente = await _livroRepository.ObterPorIdAsync(id);
            if (livroExistente == null)
                throw new KeyNotFoundException("Livro não encontrado.");

            return await _livroRepository.DeletarAsync(id);
        }

        public async Task<Livro?> ObterPorIdAsync(int id)
        {
            return await _livroRepository.ObterPorIdAsync(id);
        }

        public async Task<IEnumerable<Livro>> ObterTodosAsync()
        {
            return await _livroRepository.ObterTodosAsync();
        }
    }
}
