using Core.Contracts;
using Microsoft.Extensions.Caching.Memory;

namespace Core.Services
{
    public class CacheService<T>(IMemoryCache cache) : ICacheService<T> where T : class, new()
    {
        public T? GetCache(string key)
        {
            cache.TryGetValue(key, out T? cachedData);

            return cachedData;
        }

        public void SetCache(string key, T value, TimeSpan expirty)
        {
            cache.Set(key, value, new MemoryCacheEntryOptions().SetAbsoluteExpiration(expirty));
        }
    }
}