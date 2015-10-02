using System.Collections.Generic;
using Newtonsoft.Json;

namespace GP.DAL.Folketinget.Model
{
    public class FolkeTingetResponse<T> where T : FolketingetModel
    {
        [JsonProperty("odata.metadata")]
        public string Metadata { get; set; }

        [JsonProperty("value")]
        public IEnumerable<T> Value { get; set; }

        [JsonProperty("odata.nextLink")]
        public string NextLink { get; set; }
    }
}