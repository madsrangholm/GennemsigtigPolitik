using System;
using System.Runtime.Caching;

namespace GP.BLL.Caching
{
    public static class CachePolicies
    {
        public static CacheItemPolicy OneDay => new CacheItemPolicy {AbsoluteExpiration = DateTime.Now.AddDays(1)};
        public static CacheItemPolicy OneHour => new CacheItemPolicy {AbsoluteExpiration = DateTime.Now.AddHours(1)};
    }
}