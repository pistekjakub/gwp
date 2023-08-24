using Microsoft.Extensions.Caching.Memory;

namespace gwp.Services
{
    public class CacheService : ICacheService
    {
        private readonly IMemoryCache _memoryCache;

        public CacheService(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public object? GetValue(string key)
        {
            if (_memoryCache.TryGetValue(key, out object? value))
            {
                return value;
            }

            return null; 
        }

        public T? GetValue<T>(string key)
        {
            return _memoryCache.Get<T>(key);
        }

        public void SetValue(string key, object value)
        {
            _memoryCache.Set(key, value);
        }
    }
}
