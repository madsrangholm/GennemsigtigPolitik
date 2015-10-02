using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using GP.BLL.Caching;
using GP.BLL.Interfaces.Caching;
using GP.BLL.Interfaces.DAL.Folketinget;
using GP.DAL.Folketinget.Interfaces;
using GP.DAL.Folketinget.Model;
using GP.DAL.Folketinget.Model.Aktør;
using GP.DAL.Folketinget.Model.Dokument;
using GP.DAL.Folketinget.Model.Møde;
using GP.DAL.Folketinget.Model.Øvrige;
using Newtonsoft.Json;

namespace GP.DAL.Folketinget
{
    public class FolketingetServiceRepository : IFolketingetServiceRepository
    {
        private readonly IGlobalCache _cache;
        private readonly string _cachePrefix;
        private readonly IFolketingetConfig _config;

        public FolketingetServiceRepository(IGlobalCache cache, IFolketingetConfig config)
        {
            _cache = cache;
            _config = config;
            _cachePrefix = GetType().ToString();
        }

        public IEnumerable<Aktør> AktørList()
        {
            var key = CacheKey.Get(_cachePrefix + "AktørList");
            lock (key)
            {
                var result = _cache.Get<IEnumerable<Aktør>>(key);
                if (result != null) return result;
                result = GetList<Aktør>(_config.AktørUrl).Result;
                _cache.Set(key, result, CachePolicies.OneHour);
                return result;
            }
        }

        public IEnumerable<AktørAktør> AktørAktørList()
        {
            var key = CacheKey.Get(_cachePrefix + "AktørAktørList");
            lock (key)
            {
                var result = _cache.Get<IEnumerable<AktørAktør>>(key);
                if (result != null) return result;
                result = GetList<AktørAktør>(_config.AktørAktørUrl).Result;
                _cache.Set(key, result, CachePolicies.OneHour);
                return result;
            }
        }

        public IEnumerable<AktørType> AktørTypeList()
        {
            var key = CacheKey.Get(_cachePrefix + "AktørTypeList");
            lock (key)
            {
                var result = _cache.Get<IEnumerable<AktørType>>(key);
                if (result != null) return result;
                result = GetList<AktørType>(_config.AktørTypeUrl).Result;
                _cache.Set(key, result, CachePolicies.OneHour);
                return result;
            }
        }

        public IEnumerable<Dokument> DokumentList()
        {
            var key = CacheKey.Get(_cachePrefix + "DokumentList");
            lock (key)
            {
                var result = _cache.Get<IEnumerable<Dokument>>(key);
                if (result != null) return result;
                result = GetList<Dokument>(_config.DokumentUrl).Result;
                _cache.Set(key, result, CachePolicies.OneHour);
                return result;
            }
        }

        public IEnumerable<Dokumentation> DokumentationList()
        {
            var key = CacheKey.Get(_cachePrefix + "DokumentationList");
            lock (key)
            {
                var result = _cache.Get<IEnumerable<Dokumentation>>(key);
                if (result != null) return result;
                result = GetList<Dokumentation>(_config.DokumentationUrl).Result;
                _cache.Set(key, result, CachePolicies.OneHour);
                return result;
            }
        }

        public IEnumerable<DokumentKategori> DokumentKategoriList()
        {
            var key = CacheKey.Get(_cachePrefix + "DokumentKategoriList");
            lock (key)
            {
                var result = _cache.Get<IEnumerable<DokumentKategori>>(key);
                if (result != null) return result;
                result = GetList<DokumentKategori>(_config.DokumentKategoriUrl).Result;
                _cache.Set(key, result, CachePolicies.OneHour);
                return result;
            }
        }

        public IEnumerable<DokumentStatus> DokumentStatusList()
        {
            var key = CacheKey.Get(_cachePrefix + "DokumentStatusList");
            lock (key)
            {
                var result = _cache.Get<IEnumerable<DokumentStatus>>(key);
                if (result != null) return result;
                result = GetList<DokumentStatus>(_config.DokumentStatusUrl).Result;
                _cache.Set(key, result, CachePolicies.OneHour);
                return result;
            }
        }

        public IEnumerable<DokumentType> DokumentTypeList()
        {
            var key = CacheKey.Get(_cachePrefix + "DokumentTypeList");
            lock (key)
            {
                var result = _cache.Get<IEnumerable<DokumentType>>(key);
                if (result != null) return result;
                result = GetList<DokumentType>(_config.DokumentTypeUrl).Result;
                _cache.Set(key, result, CachePolicies.OneHour);
                return result;
            }
        }

        public IEnumerable<Fil> FilList()
        {
            var key = CacheKey.Get(_cachePrefix + "FilList");
            lock (key)
            {
                var result = _cache.Get<IEnumerable<Fil>>(key);
                if (result != null) return result;
                result = GetList<Fil>(_config.FilUrl).Result;
                _cache.Set(key, result, CachePolicies.OneHour);
                return result;
            }
        }

        public IEnumerable<Nyhed> NyhedList()
        {
            var key = CacheKey.Get(_cachePrefix + "NyhedList");
            lock (key)
            {
                var result = _cache.Get<IEnumerable<Nyhed>>(key);
                if (result != null) return result;
                result = GetList<Nyhed>(_config.NyhedUrl).Result;
                _cache.Set(key, result, CachePolicies.OneHour);
                return result;
            }
        }

        public IEnumerable<Omtryk> OmtrykList()
        {
            var key = CacheKey.Get(_cachePrefix + "OmtrykList");
            lock (key)
            {
                var result = _cache.Get<IEnumerable<Omtryk>>(key);
                if (result != null) return result;
                result = GetList<Omtryk>(_config.OmtrykUrl).Result;
                _cache.Set(key, result, CachePolicies.OneHour);
                return result;
            }
        }

        public IEnumerable<Tale> TaleList()
        {
            var key = CacheKey.Get(_cachePrefix + "TaleList");
            lock (key)
            {
                var result = _cache.Get<IEnumerable<Tale>>(key);
                if (result != null) return result;
                result = GetList<Tale>(_config.TaleUrl).Result;
                _cache.Set(key, result, CachePolicies.OneHour);
                return result;
            }
        }

        public IEnumerable<Video> VideoList()
        {
            var key = CacheKey.Get(_cachePrefix + "VideoList");
            lock (key)
            {
                var result = _cache.Get<IEnumerable<Video>>(key);
                if (result != null) return result;
                result = GetList<Video>(_config.VideoUrl).Result;
                _cache.Set(key, result, CachePolicies.OneHour);
                return result;
            }
        }

        public IEnumerable<Afstemning> AfstemningList()
        {
            var key = CacheKey.Get(_cachePrefix + "AfstemningList");
            lock (key)
            {
                var result = _cache.Get<IEnumerable<Afstemning>>(key);
                if (result != null) return result;
                result = GetList<Afstemning>(_config.AfstemningUrl).Result;
                _cache.Set(key, result, CachePolicies.OneHour);
                return result;
            }
        }

        public IEnumerable<Afstemningstype> AfstemningstypeList()
        {
            var key = CacheKey.Get(_cachePrefix + "AfstemningstypeList");
            lock (key)
            {
                var result = _cache.Get<IEnumerable<Afstemningstype>>(key);
                if (result != null) return result;
                result = GetList<Afstemningstype>(_config.AfstemningstypeUrl).Result;
                _cache.Set(key, result, CachePolicies.OneHour);
                return result;
            }
        }

        public IEnumerable<Dagsordenspunkt> DagsordenspunktList()
        {
            var key = CacheKey.Get(_cachePrefix + "DagsordenspunktList");
            lock (key)
            {
                var result = _cache.Get<IEnumerable<Dagsordenspunkt>>(key);
                if (result != null) return result;
                result = GetList<Dagsordenspunkt>(_config.DagsordenspunktUrl).Result;
                _cache.Set(key, result, CachePolicies.OneHour);
                return result;
            }
        }

        public IEnumerable<Møde> MødeList()
        {
            var key = CacheKey.Get(_cachePrefix + "MødeList");
            lock (key)
            {
                var result = _cache.Get<IEnumerable<Møde>>(key);
                if (result != null) return result;
                result = GetList<Møde>(_config.MødeUrl).Result;
                _cache.Set(key, result, CachePolicies.OneHour);
                return result;
            }
        }

        public IEnumerable<MødeStatus> MødeStatusList()
        {
            var key = CacheKey.Get(_cachePrefix + "MødeStatusList");
            lock (key)
            {
                var result = _cache.Get<IEnumerable<MødeStatus>>(key);
                if (result != null) return result;
                result = GetList<MødeStatus>(_config.MødeStatusUrl).Result;
                _cache.Set(key, result, CachePolicies.OneHour);
                return result;
            }
        }

        public IEnumerable<MødeType> MødeTypeList()
        {
            var key = CacheKey.Get(_cachePrefix + "MødeTypeList");
            lock (key)
            {
                var result = _cache.Get<IEnumerable<MødeType>>(key);
                if (result != null) return result;
                result = GetList<MødeType>(_config.MødeTypeUrl).Result;
                _cache.Set(key, result, CachePolicies.OneHour);
                return result;
            }
        }

        public IEnumerable<Stemme> StemmeList()
        {
            var key = CacheKey.Get(_cachePrefix + "StemmeList");
            lock (key)
            {
                var result = _cache.Get<IEnumerable<Stemme>>(key);
                if (result != null) return result;
                result = GetList<Stemme>(_config.StemmeUrl).Result;
                _cache.Set(key, result, CachePolicies.OneHour);
                return result;
            }
        }

        public IEnumerable<StemmeType> StemmeTypeList()
        {
            var key = CacheKey.Get(_cachePrefix + "StemmeTypeList");
            lock (key)
            {
                var result = _cache.Get<IEnumerable<StemmeType>>(key);
                if (result != null) return result;
                result = GetList<StemmeType>(_config.StemmeTypeUrl).Result;
                _cache.Set(key, result, CachePolicies.OneHour);
                return result;
            }
        }

        public IEnumerable<KolonneBeskrivelse> KolonneBeskrivelseList()
        {
            var key = CacheKey.Get(_cachePrefix + "KolonneBeskrivelseList");
            lock (key)
            {
                var result = _cache.Get<IEnumerable<KolonneBeskrivelse>>(key);
                if (result != null) return result;
                result = GetList<KolonneBeskrivelse>(_config.KolonneBeskrivelseUrl).Result;
                _cache.Set(key, result, CachePolicies.OneHour);
                return result;
            }
        }

        public IEnumerable<Slettet> SlettetList()
        {
            var key = CacheKey.Get(_cachePrefix + "SlettetList");
            lock (key)
            {
                var result = _cache.Get<IEnumerable<Slettet>>(key);
                if (result != null) return result;
                result = GetList<Slettet>(_config.SlettetUrl).Result;
                _cache.Set(key, result, CachePolicies.OneHour);
                return result;
            }
        }

        public IEnumerable<SlettetMap> SlettetMapList()
        {
            var key = CacheKey.Get(_cachePrefix + "SlettetMapList");
            lock (key)
            {
                var result = _cache.Get<IEnumerable<SlettetMap>>(key);
                if (result != null) return result;
                result = GetList<SlettetMap>(_config.SlettetMapUrl).Result;
                _cache.Set(key, result, CachePolicies.OneHour);
                return result;
            }
        }

        public IEnumerable<TabelBeskrivelse> TabelBeskrivelseList()
        {
            var key = CacheKey.Get(_cachePrefix + "TabelBeskrivelseList");
            lock (key)
            {
                var result = _cache.Get<IEnumerable<TabelBeskrivelse>>(key);
                if (result != null) return result;
                result = GetList<TabelBeskrivelse>(_config.TabelBeskrivelseUrl).Result;
                _cache.Set(key, result, CachePolicies.OneHour);
                return result;
            }
        }


        private static async Task<IEnumerable<T>> GetList<T>(string startUrl) where T : FolketingetModel
        {
            var result = new List<T>();
            using (var client = new HttpClient())
            {
                var json = client.GetStringAsync(startUrl);
                var response = JsonConvert.DeserializeObject<FolkeTingetResponse<T>>(await json);
                if (response?.Value == null) return null;
                result.AddRange(response.Value);
                while (!string.IsNullOrWhiteSpace(response.NextLink))
                {
                    json = client.GetStringAsync(response.NextLink);
                    response = JsonConvert.DeserializeObject<FolkeTingetResponse<T>>(await json);
                    result.AddRange(response.Value);
                }
            }
            return result;
        }
    }
}