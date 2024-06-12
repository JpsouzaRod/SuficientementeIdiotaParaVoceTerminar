using Microsoft.Data.SqlClient;
using System.Data;

namespace TrabalhoIdiota.Adapter.SQL.Configuration
{
    public class SQLContext
    {
        public SQLContext(IConfiguration config) 
        {
            _dbConnectionString = config.GetConnectionString("SQL");
        }

        private string _dbConnectionString;

        public IDbConnection ConnectCLUST05() => new SqlConnection(_dbConnectionString);
    }
}
