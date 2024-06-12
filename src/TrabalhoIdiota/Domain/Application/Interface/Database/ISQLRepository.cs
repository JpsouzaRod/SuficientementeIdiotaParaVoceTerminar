using TrabalhoIdiota.Domain.Core;

namespace TrabalhoIdiota.Domain.Application.Interface.Database
{
    public interface ISQLRepository
    {
        public string GetName(string name);
        public void PostName(Pessoa pessoa);
        public void DeleteName(string name);
    }
}
