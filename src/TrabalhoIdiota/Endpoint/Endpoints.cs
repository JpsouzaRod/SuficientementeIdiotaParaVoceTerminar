using TrabalhoIdiota.Domain.Application.Interface;
using TrabalhoIdiota.Domain.Core;

namespace TrabalhoIdiota.Endpoint
{
    public static class Endpoints
    {
        public static void AddEndpoints(this WebApplication app)
        {
            app.MapGet("/", () =>
            {
                return "Hello World";
            });

            app.MapPost("/cadastrar", (Pessoa pessoa, IUsecase _usecase) =>
            {
                _usecase.PostName(pessoa);
            });

            app.MapGet("/buscar", (string name, IUsecase _usecase) =>
            {
                return _usecase.GetName(name);
            });
            
            app.MapGet("/listar", (IUsecase _usecase) =>
            {
                return _usecase.ListName();
            });

            app.MapDelete("/apagar", (string name, IUsecase _usecase) =>
            {
                _usecase.DeleteName(name);
            });
        }
    }
}
