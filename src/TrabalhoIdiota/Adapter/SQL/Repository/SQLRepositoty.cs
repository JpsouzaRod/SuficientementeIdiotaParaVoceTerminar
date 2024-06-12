using Dapper;
using TrabalhoIdiota.Adapter.SQL.Configuration;
using TrabalhoIdiota.Domain.Application.Interface.Database;
using TrabalhoIdiota.Domain.Core;

namespace TrabalhoIdiota.Adapter.SQL.Repository
{
    public class SQLRepositoty : ISQLRepository
    {
        public SQLRepositoty(SQLContext DbContext)
        {
            dBContext = DbContext;
        }

        private SQLContext dBContext;
        public void DeleteName(string name)
        {
            using(var connection = dBContext.ConnectCLUST05())
            {
                var command = "DELETE FROM DadosPEssoais WHERE Nome = @nome";
                var result = connection.ExecuteAsync(command, new {nome = name});
            }
        }

        public string GetName(string name)
        {
            using (var connection = dBContext.ConnectCLUST05())
            {
                var command = "SELECT Nome FROM DadosPEssoais WHERE Nome = @nome";
                var result = connection.QueryFirst<string>(command, new {nome = name});

                return result;
            }
        }

        public void PostName(Pessoa pessoa)
        {
            using (var connection = dBContext.ConnectCLUST05())
            {
                var command = "INSERT INTO DadosPEssoais (Id, Nome) VALUES (@id, @name)";
                connection.Query(command, new {id = pessoa.Id, name = pessoa.Nome});
            }
        }
    }
}
