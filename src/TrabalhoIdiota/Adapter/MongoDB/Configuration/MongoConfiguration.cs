using TrabalhoIdiota.Adapter.MongoDB.Repository;
using TrabalhoIdiota.Domain.Application.Interface.Database;

namespace TrabalhoIdiota.Adapter.MongoDB.Configuration
{
    public static class MongoConfiguration
    {
        public static IServiceCollection AddMongo(this IServiceCollection services)
        {
            services.AddScoped<IMongoRepository, MongoRepository>();

            return services;
        }
    }
}
