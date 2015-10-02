using System;
using Newtonsoft.Json;

namespace GP.DAL.Folketinget.Model.Dokument
{
    public class Video : FolketingetModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("mødeid")]
        public int MødeId { get; set; }

        [JsonProperty("opdateringsdato")]
        public DateTime Opdateringsdato { get; set; }

        [JsonProperty("videourl")]
        public string VideoUrl { get; set; }
    }
}