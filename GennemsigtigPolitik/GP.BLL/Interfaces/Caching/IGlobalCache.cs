using System.Diagnostics.Contracts;
using System.Runtime.Caching;
using GP.BLL.Caching;

namespace GP.BLL.Interfaces.Caching
{
    [ContractClass(typeof (GlobalCacheContracts))]
    public interface IGlobalCache
    {
        void Set(CacheKey key, object data, CacheItemPolicy policy);
        T Get<T>(CacheKey key);
        void Remove(CacheKey key);
    }

    [ContractClassFor(typeof (IGlobalCache))]
    public abstract class GlobalCacheContracts : IGlobalCache
    {
        public void Set(CacheKey key, object data, CacheItemPolicy policy)
        {
            Contract.Requires(key != null);
            Contract.Requires(data != null);
            Contract.Requires(policy != null);
        }

        public T Get<T>(CacheKey key)
        {
            Contract.Requires(key != null);
            return default(T);
        }

        public void Remove(CacheKey key)
        {
            Contract.Requires(key != null);
        }
    }
}