using StackExchange.Redis;
using System.Threading.Tasks;

namespace RedisMasterSlave.Services
{
    public class RedisCacheService : ICacheService
    {
        private readonly IConnectionMultiplexer _connectionMultiplexer;

        public RedisCacheService(IConnectionMultiplexer connectionMultiplexer)
        {
            _connectionMultiplexer = connectionMultiplexer;
        }
        public async Task<string> GetCacheValueAsync(string cacheKey)
        {
            var db = _connectionMultiplexer.GetDatabase();
            return await db.StringGetAsync(cacheKey);
        }

        public async Task SetCacheValueAsync(string cacheKey, string value)
        {
            var db = _connectionMultiplexer.GetDatabase();
            await db.StringSetAsync(cacheKey, value);

        }
    }
}
