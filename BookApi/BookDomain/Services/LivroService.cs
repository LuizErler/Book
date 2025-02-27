using BookDomain.Entities;
using BookDomain.Repositories;

namespace BookDomain.Services
{
    public class LivroService : ILivroService
    {
        private readonly ILivroRepository _livroRepository;
        private readonly IAssuntoRepository _assuntoRepository;
        private readonly IAutorRepository _autorRepository;

        public LivroService(ILivroRepository livroRepository, IAssuntoRepository assuntoRepository, IAutorRepository autorRepository)
        {
            _livroRepository = livroRepository;
            _assuntoRepository = assuntoRepository;
            _autorRepository = autorRepository;

        }

        public async Task<int> AdicionarAsync(Livro livro)
        {
            if (string.IsNullOrWhiteSpace(livro.Titulo))
                throw new ArgumentException("O título do livro não pode ser vazio.");

            if (livro.Edicao < 1)
                throw new ArgumentException("A edição do livro deve ser maior que 0.");

            var codLivro = await _livroRepository.AdicionarAsync(livro);

            foreach (var item in livro.AssuntoIds)
            {
                await _assuntoRepository.AdicionarLivroAssuntoAsync(codLivro, item ?? 0);
            }
            foreach (var item in livro.AutorIds)
            {
                await _autorRepository.AdicionarLivroAutorAsync(codLivro, item ?? 0);
            }


            return codLivro;
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

            var livroAutorExistente = await _autorRepository.ObterLivroAutorPorIdAsync(id);
            var livroAssuntoExistente = await _assuntoRepository.ObterLivroAssuntoPorIdAsync(id);

            await DeletarLivroAutor(livroAutorExistente);
            await DeletarLivroAssunto(livroAssuntoExistente);

            return await _livroRepository.DeletarAsync(id);
        }

        private async Task DeletarLivroAssunto(IEnumerable<LivroAssunto> livroAssuntoExistente)
        {
            foreach (var item in livroAssuntoExistente)
            {
                var result = await _assuntoRepository.DeletarLivroAssuntoAsync(item.CodLivro);
            }
        }

        private async Task DeletarLivroAutor(IEnumerable<LivroAutor> livroAutorExistente)
        {
            foreach (var item in livroAutorExistente)
            {
                var result = await _autorRepository.DeletarLivroAutorAsync(item.CodLivro);
            }
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
