using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Data;

namespace DesafioBackEndInfra
{
    public class BaseDb
    {
        private readonly IConfiguration _configuration;

        public BaseDb(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public IDbConnection GetConnection()
        {
            var connectionString = _configuration.GetConnectionString("DefaultConnection");
            return new NpgsqlConnection(connectionString);
        }
        public string GetConnectionString()
        {
            return _configuration.GetConnectionString("DefaultConnection");
        }
    }
}
