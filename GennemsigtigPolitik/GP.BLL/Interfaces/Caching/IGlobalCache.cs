using System.Diagnostics.Contracts;
using System.Runtime.Caching;
using System.Threading.Tasks;
using GP.BLL.Caching;

namespace GP.BLL.Interfaces.Caching
{
    [ContractClass(typeof (GlobalCacheContracts))]
    public interface IGlobalCache
    {
        void Set<T>(CacheKey key, Task<T> data, CacheItemPolicy policy);
        Task<T> Get<T>(CacheKey key);
        void Remove(CacheKey key);
    }

    [ContractClassFor(typeof (IGlobalCache))]
    public abstract class GlobalCacheContracts : IGlobalCache
    {
        public void Set<T>(CacheKey key, Task<T> data, CacheItemPolicy policy)
        {
            Contract.Requires(key != null);
            Contract.Requires(data != null);
            Contract.Requires(policy != null);
        }

        public Task<T> Get<T>(CacheKey key)
        {
            Contract.Requires(key != null);
            return default(Task<T>);
        }

        public void Remove(CacheKey key)
        {
            Contract.Requires(key != null);
        }
    }
}