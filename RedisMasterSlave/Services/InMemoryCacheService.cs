using Microsoft.Extensions.Caching.Memory;
using System.Threading.Tasks;

namespace RedisMasterSlave.Services
{
    public class InMemoryCacheService : ICacheService
    {
        private readonly MemoryCache _cache = new MemoryCache(new MemoryCacheOptions());
        public Task<string> GetCacheValueAsync(string cacheKey)
        {
            return Task.FromResult(_cache.Get<string>(cacheKey));
        }

        public Task SetCacheValueAsync(string cacheKey, string value)
        {
            _cache.Set(cacheKey, value);
            return Task.CompletedTask;
        }

        
    }
}
