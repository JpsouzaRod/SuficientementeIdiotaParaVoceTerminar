using TrabalhoIdiota.Domain.Application.Interface;

namespace TrabalhoIdiota.Domain.Application.Service
{
    public class Service : IService
    {
        public string GetHelloWorld()
        {
            return "Hello World";
        }
    }
}
