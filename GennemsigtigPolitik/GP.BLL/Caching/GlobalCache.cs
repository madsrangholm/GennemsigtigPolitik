using System.Runtime.Caching;
using System.Threading.Tasks;
using GP.BLL.Interfaces.Caching;

namespace GP.BLL.Caching
{
    public class GlobalCache : IGlobalCache
    {
        private readonly object _lock;
        private readonly ObjectCache _cache;

        public GlobalCache()
        {
            _lock = new object();
            _cache = MemoryCache.Default;
        }

        public void Set<T>(CacheKey key, Task<T> data, CacheItemPolicy policy)
        {
            lock (_lock)
            {
                _cache.Set(key.Value, data, policy);
            }
        }

        public Task<T> Get<T>(CacheKey key)
        {
            lock (_lock)
            {
                return (Task<T>) _cache.Get(key.Value);
            }
        }

        public void Remove(CacheKey key)
        {
            lock (_lock)
            {
                _cache.Remove(key.Value);
            }
        }
    }
}