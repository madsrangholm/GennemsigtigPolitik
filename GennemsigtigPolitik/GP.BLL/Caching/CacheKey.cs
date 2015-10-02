using System.Collections.Concurrent;
using System.Diagnostics.Contracts;

namespace GP.BLL.Caching
{
    public class CacheKey
    {
        public CacheKey(string value)
        {
            Contract.Requires(!string.IsNullOrWhiteSpace(value));
            Contract.Ensures(!string.IsNullOrWhiteSpace(Value));
            Value = value;
        }

        public string Value { get; }

        [ContractInvariantMethod]
        private void Invariants()
        {
            Contract.Invariant(!string.IsNullOrWhiteSpace(Value));
        }

        #region Static functions for getting keys

        private static readonly ConcurrentDictionary<string, CacheKey> Keys =
            new ConcurrentDictionary<string, CacheKey>();

        public static CacheKey Get(string key)
        {
            return Keys.GetOrAdd(key, new CacheKey(key));
        }

        #endregion
    }
}