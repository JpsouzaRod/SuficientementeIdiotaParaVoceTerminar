using TrabalhoIdiota.Adapter.Redis.Repository;
using TrabalhoIdiota.Domain.Application.Interface.Database;

namespace TrabalhoIdiota.Adapter.Redis.Configuration
{
    public static class RedisConfiguration
    {
        public static IServiceCollection AddRedisCache(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryCache, RepositoryCache>();

            return services;
        }
    }
}
