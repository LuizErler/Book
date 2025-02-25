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
            using (var conn = _baseDb.GetConnection())
            {
                var sql = "INSERT INTO Assunto (Descricao) VALUES (@Descricao) RETURNING CodAs;";
                return await conn.ExecuteScalarAsync<int>(sql, new { assunto.Descricao });
            }
        }

        public async Task<bool> AtualizarAssuntoAsync(Assunto assunto)
        {
            using (var conn = _baseDb.GetConnection())
            {
                var sql = "UPDATE Assunto SET Descricao = @Descricao WHERE CodAs = @CodAs;";
                var rowsAffected = await conn.ExecuteAsync(sql, new { assunto.Descricao, assunto.CodAs });
                return rowsAffected > 0;
            }
        }

        public async Task<bool> DeletarAssuntoAsync(int id)
        {
            using (var conn = _baseDb.GetConnection())
            {
                var sql = "DELETE FROM Assunto WHERE CodAs = @CodAs;";
                var rowsAffected = await conn.ExecuteAsync(sql, new { CodAs = id });
                return rowsAffected > 0;
            }
        }

        public async Task<Assunto> ObterAssuntoPorIdAsync(int id)
        {
            using (var conn = _baseDb.GetConnection())
            {
                var sql = "SELECT * FROM Assunto WHERE CodAs = @CodAs;";
                return await conn.QueryFirstOrDefaultAsync<Assunto>(sql, new { CodAs = id });
            }
        }

        public async Task<IEnumerable<Assunto>> ObterTodosAssuntosAsync()
        {
            using (var conn = _baseDb.GetConnection())
            {
                var sql = "SELECT * FROM Assunto;";
                return await conn.QueryAsync<Assunto>(sql);
            }
        }
    }
}
