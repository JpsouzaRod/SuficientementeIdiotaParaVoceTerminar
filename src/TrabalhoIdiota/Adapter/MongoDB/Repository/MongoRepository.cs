using MongoDB.Driver;
using TrabalhoIdiota.Adapter.MongoDB.Configuration;
using TrabalhoIdiota.Domain.Application.Interface.Database;
using TrabalhoIdiota.Domain.Core;

namespace TrabalhoIdiota.Adapter.MongoDB.Repository
{
    public class MongoRepository : IMongoRepository 
    {
        public MongoRepository(IConfiguration config) 
        {
            var client = new MongoClient(config.GetConnectionString("Mongo"));
            collection = client.GetDatabase("MongoDB").GetCollection<Pessoa>("DadosPessoais");
        }

        private IMongoCollection<Pessoa> collection;

        public void PostName(Pessoa pessoa)
        {
            collection.InsertOne(pessoa);
        }
        public void DeleteName(string nome)
        {
            collection.DeleteOne(p => p.Nome == nome);
        }

        public Pessoa GetName(string nome)
        {
            return collection.Find<Pessoa>(p => p.Nome == nome).First();
        }

        public List<Pessoa> ListName()
        {
            return collection.Find(p => true).ToList();
        }
    }
}
