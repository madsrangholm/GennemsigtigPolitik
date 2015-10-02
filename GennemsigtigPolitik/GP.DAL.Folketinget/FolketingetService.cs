using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using GP.BLL.Interfaces.DAL.Folketinget;
using GP.BLL.Model.Folketinget;
using GP.DAL.Folketinget.Model;
using GP.DAL.Folketinget.Model.Aktør;
using Newtonsoft.Json;

namespace GP.DAL.Folketinget
{
    // This project can output the Class library as a NuGet Package.
    // To enable this option, right-click on the project and select the Properties menu item. In the Build tab select "Produce outputs on build".
    public class FolketingetService : IFolketingetService
    {
        private readonly IFolketingetConfig _settings;

        public FolketingetService(IFolketingetConfig settings)
        {
            _settings = settings;
        }

        public async Task<IEnumerable<Actor>> GetActors()
        {
            return (await GetList<Aktør>(_settings.AktørUrl)).Select(x => x.ToActor());
        }
        
        private static async Task<IEnumerable<T>> GetList<T>(string startUrl) where T : FolketingetModel
        {
            var result = new List<T>();
            using (var client = new HttpClient())
            {
                var json = client.GetStringAsync(startUrl);
                var response = JsonConvert.DeserializeObject<FolkeTingetResponse<T>>(await json);
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