using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Data;

namespace DesafioBackEndInfra
{
    public class BaseDb : IDisposable
    {
        private readonly IConfiguration _configuration;
        private readonly Lazy<IDbConnection> _connection;

        public BaseDb(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _connection = new Lazy<IDbConnection>(CreateConnection);
        }

        private IDbConnection CreateConnection()
        {
            var connectionString = _configuration.GetConnectionString("DefaultConnection");
            var conn = new NpgsqlConnection(connectionString);
            conn.Open(); // Abre a conexão automaticamente
            return conn;
        }

        public IDbConnection GetConnection()
        {
            if (_connection.Value.State == ConnectionState.Closed)
            {
                _connection.Value.Open();
            }
            return _connection.Value;
        }

        public void Dispose()
        {
            if (_connection.IsValueCreated)
            {
                _connection.Value.Dispose();
            }
        }
    }
}
