using TrabalhoIdiota.Domain.Core;

namespace TrabalhoIdiota.Domain.Application.Interface.Database
{
    public interface IMongoRepository
    {
        public Pessoa GetName(string name);
        public List<Pessoa> ListName();
        public void PostName(Pessoa pessoa);
        public void DeleteName(string name);
    }
}