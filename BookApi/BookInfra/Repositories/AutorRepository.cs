using BookDomain.Entities;
using BookDomain.Repositories;
using DesafioBackEndInfra;
using Dapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookInfra.Repositories
{
    public class AutorRepository : IAutorRepository
    {
        private readonly BaseDb _baseDb;

        public AutorRepository(BaseDb baseDb)
        {
            _baseDb = baseDb;
        }

        public async Task<int> AdicionarAsync(Autor autor)
        {
            var query = "INSERT INTO public.autor (Nome) VALUES (@Nome) RETURNING CodAu";
            using var connection = _baseDb.GetConnection();
            return await connection.ExecuteScalarAsync<int>(query, new { autor.Nome });
        }

        public async Task<bool> AtualizarAsync(Autor autor)
        {
            var query = "UPDATE public.autor SET Nome = @Nome WHERE CodAu = @CodAu";
            using var connection = _baseDb.GetConnection();
            var result = await connection.ExecuteAsync(query, new { autor.Nome, autor.CodAu });
            return result > 0;
        }

        public async Task<bool> DeletarAsync(int id)
        {
            var query = "DELETE FROM public.autor WHERE CodAu = @CodAu";
            using var connection = _baseDb.GetConnection();
            var result = await connection.ExecuteAsync(query, new { CodAu = id });
            return result > 0;
        }

        public async Task<Autor> ObterPorIdAsync(int id)
        {
            var query = "SELECT CodAu, Nome FROM public.autor WHERE CodAu = @CodAu";
            using var connection = _baseDb.GetConnection();
            return await connection.QueryFirstOrDefaultAsync<Autor>(query, new { CodAu = id });
        }

        public async Task<IEnumerable<Autor>> ObterTodosAsync()
        {
            var query = "SELECT CodAu, Nome FROM public.autor";
            using var connection = _baseDb.GetConnection();
            return await connection.QueryAsync<Autor>(query);
        }

        public async Task<IEnumerable<LivroAutor>> ObterLivroAutorPorIdAsync(int id)
        {
            var query = "SELECT livro_codl AS CodLivro, autor_codau AS CodAutor FROM public.livro_autor WHERE livro_codl = @CodLivro";
            using var connection = _baseDb.GetConnection();
            return await connection.QueryAsync<LivroAutor>(query, new { CodLivro = id });
        }

        public async Task<bool> DeletarLivroAutorAsync(int id)
        {
            var query = "DELETE FROM public.livro_autor WHERE livro_codl = @CodLivro";
            using var connection = _baseDb.GetConnection();
            var result = await connection.ExecuteAsync(query, new { CodLivro = id });
            return result > 0;
        }

        public async Task AdicionarLivroAutorAsync(int codLivro, int codAutor)
        {
            var query = "INSERT INTO public.livro_autor (livro_codl, autor_codau) VALUES (@CodLivro, @CodAutor)";
            using var connection = _baseDb.GetConnection();
            await connection.ExecuteAsync(query, new { CodLivro = codLivro, CodAutor = codAutor });
        }
    }
}
