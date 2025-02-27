using BookDomain.Entities;
using BookDomain.Repositories;
using Dapper;
using DesafioBackEndInfra;

namespace BookInfra.Repositories
{
    public class AssuntoRepository : IAssuntoRepository
    {
        private readonly BaseDb _baseDb;

        public AssuntoRepository(BaseDb baseDb)
        {
            _baseDb = baseDb;
        }

        public async Task<int> AdicionarAssuntoAsync(Assunto assunto)
        {
            var query = "INSERT INTO Assunto (Descricao) VALUES (@Descricao) RETURNING CodAs;";
            using var connection = _baseDb.GetConnection();
            return await connection.ExecuteScalarAsync<int>(query, new { assunto.Descricao });
        }

        public async Task<bool> AtualizarAssuntoAsync(Assunto assunto)
        {
            var query = "UPDATE Assunto SET Descricao = @Descricao WHERE CodAs = @CodAs;";
            using var connection = _baseDb.GetConnection();
            var rowsAffected = await connection.ExecuteAsync(query, new { assunto.Descricao, assunto.CodAs });
            return rowsAffected > 0;
        }

        public async Task<bool> DeletarAssuntoAsync(int id)
        {
            var query = "DELETE FROM Assunto WHERE CodAs = @CodAs;";
            using var connection = _baseDb.GetConnection();
            var rowsAffected = await connection.ExecuteAsync(query, new { CodAs = id });
            return rowsAffected > 0;
        }

        public async Task<Assunto> ObterAssuntoPorIdAsync(int id)
        {
            var query = "SELECT * FROM Assunto WHERE CodAs = @CodAs;";
            using var connection = _baseDb.GetConnection();
            return await connection.QueryFirstOrDefaultAsync<Assunto>(query, new { CodAs = id });
        }

        public async Task<IEnumerable<Assunto>> ObterTodosAssuntosAsync()
        {
            var query = "SELECT * FROM Assunto;";
            using var connection = _baseDb.GetConnection();
            return await connection.QueryAsync<Assunto>(query);
        }

        public async Task<IEnumerable<LivroAssunto>> ObterLivroAssuntoPorIdAsync(int id)
        {
            var query = "SELECT livro_codl as CodLivro, assunto_codas as CodAssunto FROM public.livro_assunto WHERE livro_codl = @codl;";
            using var connection = _baseDb.GetConnection();
            return await connection.QueryAsync<LivroAssunto>(query, new { codl = id });
        }

        public async Task<bool> DeletarLivroAssuntoAsync(int id)
        {
            var query = "DELETE FROM public.livro_assunto WHERE livro_codl = @Codl";
            using var connection = _baseDb.GetConnection();
            var result = await connection.ExecuteAsync(query, new { Codl = id });
            return result > 0;
        }

        public async Task AdicionarLivroAssuntoAsync(int CodLivro, int CodAssunto)
        {
            var query = "INSERT INTO public.livro_assunto(livro_codl, assunto_codas) VALUES (@CodLivro, @CodAssunto);";
            using var connection = _baseDb.GetConnection();
            await connection.ExecuteAsync(query, new { CodLivro, CodAssunto });
        }
    }
}
