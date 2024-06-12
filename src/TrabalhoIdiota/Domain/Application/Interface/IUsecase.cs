using TrabalhoIdiota.Domain.Core;

namespace TrabalhoIdiota.Domain.Application.Interface
{
    public interface IUsecase
    {
        string GetHelloWorld();
        void PostName(Pessoa pessoa);
        string GetName(string name);
        List<Pessoa> ListName();
        void DeleteName(string name);
    }
}
