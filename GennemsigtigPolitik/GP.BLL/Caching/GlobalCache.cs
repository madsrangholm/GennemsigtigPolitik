using System.Runtime.Caching;
using GP.BLL.Interfaces.Caching;

namespace GP.BLL.Caching
{
    public class GlobalCache : IGlobalCache
    {
        private readonly ObjectCache _cache;

        public GlobalCache()
        {
            _cache = MemoryCache.Default;
        }

        public void Set(CacheKey key, object data, CacheItemPolicy policy)
        {
            lock (key)
            {
                _cache.Set(new CacheItem(key.Value, data), policy);
            }
        }

        public T Get<T>(CacheKey key)
        {
            lock (key)
            {
                return (T) _cache.Get(key.Value);
            }
        }

        public void Remove(CacheKey key)
        {
            lock (key)
            {
                _cache.Remove(key.Value);
            }
        }
    }
}