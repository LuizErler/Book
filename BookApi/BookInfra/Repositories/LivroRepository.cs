using BookDomain.Entities;
using BookDomain.Repositories;
using Dapper;
using DesafioBackEndInfra;

namespace BookInfra.Repositories
{
    public class LivroRepository : ILivroRepository
    {
        private readonly BaseDb _baseDb;

        public LivroRepository(BaseDb baseDb)
        {
            _baseDb = baseDb;
        }

        public async Task<int> AdicionarAsync(Livro livro)
        {
            using var connection = _baseDb.GetConnection();
            string sql = @"
                INSERT INTO Livro (Titulo, Editora, Edicao, AnoPublicacao) 
                VALUES (@Titulo, @Editora, @Edicao, @AnoPublicacao) 
                RETURNING Codl;";

            return await connection.ExecuteScalarAsync<int>(sql, livro);
        }

        public async Task<bool> AtualizarAsync(Livro livro)
        {
            using var connection = _baseDb.GetConnection();
            string sql = @"
                UPDATE Livro 
                SET Titulo = @Titulo, Editora = @Editora, Edicao = @Edicao, AnoPublicacao = @AnoPublicacao 
                WHERE Codl = @Codl;";

            int rowsAffected = await connection.ExecuteAsync(sql, livro);
            return rowsAffected > 0;
        }

        public async Task<bool> DeletarAsync(int id)
        {
            using var connection = _baseDb.GetConnection();
            string sql = "DELETE FROM Livro WHERE Codl = @Id;";

            int rowsAffected = await connection.ExecuteAsync(sql, new { Id = id });
            return rowsAffected > 0;
        }

        public async Task<Livro?> ObterPorIdAsync(int id)
        {
            using var connection = _baseDb.GetConnection();
            string sql = "SELECT * FROM Livro WHERE Codl = @Id;";

            return await connection.QueryFirstOrDefaultAsync<Livro>(sql, new { Id = id });
        }

        public async Task<IEnumerable<Livro>> ObterTodosAsync()
        {
            using var connection = _baseDb.GetConnection();
            string sql = "SELECT * FROM Livro;";

            return await connection.QueryAsync<Livro>(sql);
        }
    }
}