using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Options;
using TrabalhoIdiota.Domain.Application.Interface.Database;

namespace TrabalhoIdiota.Adapter.Redis.Repository
{
    public class RepositoryCache : IRepositoryCache
    {
        public RepositoryCache(IDistributedCache cache)
        {
            _cache = cache;   
        }

        private IDistributedCache _cache;
        private DistributedCacheEntryOptions options = new DistributedCacheEntryOptions()
        {
            SlidingExpiration = TimeSpan.FromHours(3),
            AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(1),
        };

        public async Task<string> GetAsync(string key)
        {
            return await _cache.GetStringAsync(key);
        }
        public async Task SetAsync(string key, string value)
        {
            await _cache.SetStringAsync(key, value);
        }
        public async Task DeleteAsync(string key)
        {
            await _cache.RemoveAsync(key);
        }
    }
}
