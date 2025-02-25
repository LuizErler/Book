using BookDomain.Entities;
using BookDomain.Repositories;  // Alterado para importar a interface do Domain
using DesafioBackEndInfra;
using Npgsql;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;

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
            using (var connection = _baseDb.GetConnection())
            {
                var query = "INSERT INTO Autor (Nome) VALUES (@Nome) RETURNING CodAu";
                return await connection.ExecuteScalarAsync<int>(query, new { autor.Nome });
            }
        }

        public async Task<bool> AtualizarAsync(Autor autor)
        {
            using (var connection = _baseDb.GetConnection())
            {
                var query = "UPDATE Autor SET Nome = @Nome WHERE CodAu = @CodAu";
                var result = await connection.ExecuteAsync(query, new { autor.Nome, autor.CodAu });
                return result > 0;
            }
        }

        public async Task<bool> DeletarAsync(int id)
        {
            using (var connection = _baseDb.GetConnection())
            {
                var query = "DELETE FROM Autor WHERE CodAu = @CodAu";
                var result = await connection.ExecuteAsync(query, new { CodAu = id });
                return result > 0;
            }
        }

        public async Task<Autor> ObterPorIdAsync(int id)
        {
            using (var connection = _baseDb.GetConnection())
            {
                var query = "SELECT * FROM Autor WHERE CodAu = @CodAu";
                return await connection.QueryFirstOrDefaultAsync<Autor>(query, new { CodAu = id });
            }
        }

        public async Task<IEnumerable<Autor>> ObterTodosAsync()
        {
            using (var connection = _baseDb.GetConnection())
            {
                var query = "SELECT * FROM Autor";
                return await connection.QueryAsync<Autor>(query);
            }
        }
    }
}
