using System.Collections.Generic;
using System.Threading.Tasks;
using GP.BLL.Caching;
using GP.BLL.Interfaces.Caching;
using GP.BLL.Interfaces.DAL.Folketinget;
using GP.BLL.Model.Folketinget;

namespace GP.DAL.Folketinget
{
    public class FolketingetServiceCached : FolketingetService, IFolketingetService, IFolketingetServiceCached
    {
        private readonly CacheKey _getActorsCacheKey = CacheKey.Get("Folketinget.GetActors");
        private readonly IGlobalCache _cache;


        public FolketingetServiceCached(IFolketingetConfig settings, IGlobalCache cache) : base(settings)
        {
            _cache = cache;
        }

        public new async Task<IEnumerable<Actor>> GetActors()
        {

            var result = _cache.Get<IEnumerable<Actor>>(_getActorsCacheKey);
            if (result != null) return result;
            result = await base.GetActors();
            _cache.Set(_getActorsCacheKey, result, CachePolicies.OneHour);
            return result;
        }
    }
}