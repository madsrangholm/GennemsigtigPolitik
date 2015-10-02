using System;
using System.Diagnostics.Contracts;

namespace GP.BLL.Interfaces.Caching
{
    [ContractClass(typeof (SessionCacheContracts))]
    public interface ISessionCache
    {
        void Set(string key, object data, TimeSpan? expiration = null, DateTime? absoluteExpiration = null);
        T Get<T>(string key);
        void Remove(string key);
    }

    [ContractClassFor(typeof (ISessionCache))]
    public abstract class SessionCacheContracts : ISessionCache
    {
        public void Set(string key, object data, TimeSpan? expiration = null, DateTime? absoluteExpiration = null)
        {
            Contract.Requires(!string.IsNullOrWhiteSpace(key));
            Contract.Requires(data != null);
            Contract.Requires(expiration == null || absoluteExpiration == null);
        }

        public T Get<T>(string key)
        {
            Contract.Requires(!string.IsNullOrWhiteSpace(key));
            return default(T);
        }

        public void Remove(string key)
        {
            Contract.Requires(!string.IsNullOrWhiteSpace(key));
        }
    }
}