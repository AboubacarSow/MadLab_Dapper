using Microsoft.Data.SqlClient;
using System.Data;

namespace MedLab_Dapper.Repositories.Context
{
    public class DapperDbContext 
    {
        private readonly string _connectionString;

       public DapperDbContext(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("sqlConnection")!;
        }

        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
    }
}
