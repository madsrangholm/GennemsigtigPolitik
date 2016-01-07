using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.Caching;
using System.Threading.Tasks;
using GP.BLL.Caching;
using GP.BLL.Extensions;
using GP.BLL.Interfaces.Caching;
using GP.BLL.Interfaces.DAL.Folketinget;
using GP.BLL.Model.Folketinget;
using GP.DAL.Folketinget.Interfaces;
using GP.DAL.Folketinget.Model;
using GP.DAL.Folketinget.Model.Aktør;
using GP.DAL.Folketinget.Model.Dokument;
using GP.DAL.Folketinget.Model.Møde;
using GP.DAL.Folketinget.Model.Øvrige;
using Newtonsoft.Json;

namespace GP.DAL.Folketinget
{
    public class FolketingetService : IFolketingetService
    {
        private readonly IGlobalCache _cache;
        private readonly string _cachePrefix;
        private readonly IFolketingetConfig _config;

        public FolketingetService(IGlobalCache cache, IFolketingetConfig config)
        {
            _cache = cache;
            _config = config;
            _cachePrefix = GetType().ToString();
        }


        private Task<IEnumerable<TX>> TryGetFromCacheOrCreate<TX,TY>(CacheKey key, string url, CacheItemPolicy policy, Func<TY,TX> conversionFunc)
            where TY : FolketingetModel
        {
            lock (key)
            {
                var cachedTask = _cache.Get<IEnumerable<TX>>(key);
                if (cachedTask.IsValid()) return cachedTask;
                var newTask = GetList(url, conversionFunc);
                _cache.Set(key, newTask, policy);
                return newTask;
            }
        }


        private static async Task<IEnumerable<TX>> GetList<TX, TY>(string startUrl, Func<TY, TX> conversionFunc) where TY : FolketingetModel
        {
            var result = new List<TY>();
            using (var client = new HttpClient())
            {
                var json = client.GetStringAsync(startUrl);
                var response = JsonConvert.DeserializeObject<FolkeTingetResponse<TY>>(await json);
                if (response?.Value == null) return null;
                result.AddRange(response.Value);
                while (!string.IsNullOrWhiteSpace(response.NextLink))
                {
                    json = client.GetStringAsync(response.NextLink);
                    response = JsonConvert.DeserializeObject<FolkeTingetResponse<TY>>(await json);
                    result.AddRange(response.Value);
                }
            }
            return result.AsParallel().Select(conversionFunc);
        }

        public Task<IEnumerable<Actor>> GetActors()
        {
            var key = CacheKey.Get(_cachePrefix + "AktørList");
            return TryGetFromCacheOrCreate<Actor, Aktør>(key, _config.AktørUrl, CachePolicies.OneHour, aktør => aktør.ToActor());
        }

        //public Task<IEnumerable<AktørAktør>> AktørAktørList()
        //{
        //    var key = CacheKey.Get(_cachePrefix + "AktørAktørList");
        //    return TryGetFromCacheOrCreate<AktørAktør>(key, _config.AktørAktørUrl, CachePolicies.OneHour);
        //}

        //public Task<IEnumerable<AktørType>> AktørTypeList()
        //{
        //    var key = CacheKey.Get(_cachePrefix + "AktørTypeList");
        //    return TryGetFromCacheOrCreate<AktørType>(key, _config.AktørTypeUrl, CachePolicies.OneHour);
        //}

        //public Task<IEnumerable<Dokument>> DokumentList()
        //{
        //    var key = CacheKey.Get(_cachePrefix + "DokumentList");
        //    return TryGetFromCacheOrCreate<Dokument>(key, _config.DokumentUrl, CachePolicies.OneHour);
        //}

        //public Task<IEnumerable<Dokumentation>> DokumentationList()
        //{
        //    var key = CacheKey.Get(_cachePrefix + "DokumentationList");
        //    return TryGetFromCacheOrCreate<Dokumentation>(key, _config.DokumentationUrl, CachePolicies.OneHour);
        //}

        //public Task<IEnumerable<DokumentKategori>> DokumentKategoriList()
        //{
        //    var key = CacheKey.Get(_cachePrefix + "DokumentKategoriList");
        //    return TryGetFromCacheOrCreate<DokumentKategori>(key, _config.DokumentKategoriUrl, CachePolicies.OneHour);
        //}

        //public Task<IEnumerable<DokumentStatus>> DokumentStatusList()
        //{
        //    var key = CacheKey.Get(_cachePrefix + "DokumentStatusList");
        //    return TryGetFromCacheOrCreate<DokumentStatus>(key, _config.DokumentStatusUrl, CachePolicies.OneHour);
        //}

        //public Task<IEnumerable<DokumentType>> DokumentTypeList()
        //{
        //    var key = CacheKey.Get(_cachePrefix + "DokumentTypeList");
        //    return TryGetFromCacheOrCreate<DokumentType>(key, _config.DokumentTypeUrl, CachePolicies.OneHour);
        //}

        //public Task<IEnumerable<Fil>> FilList()
        //{
        //    var key = CacheKey.Get(_cachePrefix + "FilList");
        //    return TryGetFromCacheOrCreate<Fil>(key, _config.FilUrl, CachePolicies.OneHour);
        //}


        //public Task<IEnumerable<Nyhed>> NyhedList()
        //{
        //    var key = CacheKey.Get(_cachePrefix + "NyhedList");
        //    return TryGetFromCacheOrCreate<Nyhed>(key, _config.NyhedUrl, CachePolicies.OneHour);
        //}

        //public Task<IEnumerable<Omtryk>> OmtrykList()
        //{
        //    var key = CacheKey.Get(_cachePrefix + "OmtrykList");
        //    return TryGetFromCacheOrCreate<Omtryk>(key, _config.OmtrykUrl, CachePolicies.OneHour);
        //}

        //public Task<IEnumerable<Tale>> TaleList()
        //{
        //    var key = CacheKey.Get(_cachePrefix + "TaleList");
        //    return TryGetFromCacheOrCreate<Tale>(key, _config.TaleUrl, CachePolicies.OneHour);
        //}

        //public Task<IEnumerable<Video>> VideoList()
        //{
        //    var key = CacheKey.Get(_cachePrefix + "VideoList");
        //    return TryGetFromCacheOrCreate<Video>(key, _config.VideoUrl, CachePolicies.OneHour);
        //}

        //public Task<IEnumerable<Afstemning>> AfstemningList()
        //{
        //    var key = CacheKey.Get(_cachePrefix + "AfstemningList");
        //    return TryGetFromCacheOrCreate<Afstemning>(key, _config.AfstemningUrl, CachePolicies.OneHour);
        //}

        //public Task<IEnumerable<Afstemningstype>> AfstemningstypeList()
        //{
        //    var key = CacheKey.Get(_cachePrefix + "AfstemningstypeList");
        //    return TryGetFromCacheOrCreate<Afstemningstype>(key, _config.AfstemningstypeUrl, CachePolicies.OneHour);
        //}

        //public Task<IEnumerable<Dagsordenspunkt>> DagsordenspunktList()
        //{
        //    var key = CacheKey.Get(_cachePrefix + "DagsordenspunktList");
        //    return TryGetFromCacheOrCreate<Dagsordenspunkt>(key, _config.DagsordenspunktUrl, CachePolicies.OneHour);
        //}

        //public Task<IEnumerable<Møde>> MødeList()
        //{
        //    var key = CacheKey.Get(_cachePrefix + "MødeList");
        //    return TryGetFromCacheOrCreate<Møde>(key, _config.MødeUrl, CachePolicies.OneHour);
        //}

        //public Task<IEnumerable<MødeStatus>> MødeStatusList()
        //{
        //    var key = CacheKey.Get(_cachePrefix + "MødeStatusList");
        //    return TryGetFromCacheOrCreate<MødeStatus>(key, _config.MødeStatusUrl, CachePolicies.OneHour);
        //}

        //public Task<IEnumerable<MødeType>> MødeTypeList()
        //{
        //    var key = CacheKey.Get(_cachePrefix + "MødeTypeList");
        //    return TryGetFromCacheOrCreate<MødeType>(key, _config.MødeTypeUrl, CachePolicies.OneHour);
        //}

        //public Task<IEnumerable<Stemme>> StemmeList()
        //{
        //    var key = CacheKey.Get(_cachePrefix + "StemmeList");
        //    return TryGetFromCacheOrCreate<Stemme>(key, _config.StemmeUrl, CachePolicies.OneHour);
        //}

        //public Task<IEnumerable<StemmeType>> StemmeTypeList()
        //{
        //    var key = CacheKey.Get(_cachePrefix + "StemmeTypeList");
        //    return TryGetFromCacheOrCreate<StemmeType>(key, _config.StemmeTypeUrl, CachePolicies.OneHour);
        //}

        //public Task<IEnumerable<KolonneBeskrivelse>> KolonneBeskrivelseList()
        //{
        //    var key = CacheKey.Get(_cachePrefix + "KolonneBeskrivelseList");
        //    return TryGetFromCacheOrCreate<KolonneBeskrivelse>(key, _config.KolonneBeskrivelseUrl, CachePolicies.OneHour);
        //}

        //public Task<IEnumerable<Slettet>> SlettetList()
        //{
        //    var key = CacheKey.Get(_cachePrefix + "SlettetList");
        //    return TryGetFromCacheOrCreate<Slettet>(key, _config.SlettetUrl, CachePolicies.OneHour);
        //}

        //public Task<IEnumerable<SlettetMap>> SlettetMapList()
        //{
        //    var key = CacheKey.Get(_cachePrefix + "SlettetMapList");
        //    return TryGetFromCacheOrCreate<SlettetMap>(key, _config.SlettetMapUrl, CachePolicies.OneHour);
        //}

        //public Task<IEnumerable<TabelBeskrivelse>> TabelBeskrivelseList()
        //{
        //    var key = CacheKey.Get(_cachePrefix + "TabelBeskrivelseList");
        //    return TryGetFromCacheOrCreate<TabelBeskrivelse>(key, _config.TabelBeskrivelseUrl, CachePolicies.OneHour);
        //}

        
    }
}