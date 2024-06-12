using TrabalhoIdiota.Adapter.SQL.Repository;
using TrabalhoIdiota.Domain.Application.Interface.Database;

namespace TrabalhoIdiota.Adapter.SQL.Configuration
{
    public static class SQLConfiguration
    {
        public static IServiceCollection AddDatabases(this IServiceCollection services)
        {
            services.AddScoped<SQLContext>();
            services.AddScoped<ISQLRepository, SQLRepositoty>();

            return services;
        }
    }
}
