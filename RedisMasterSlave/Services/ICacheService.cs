using System.Threading.Tasks;

namespace RedisMasterSlave.Services
{
    public interface ICacheService
    {
        Task<string> GetCacheValueAsync (string cacheKey);
        Task SetCacheValueAsync (string cacheKey, string value);
    }
}
