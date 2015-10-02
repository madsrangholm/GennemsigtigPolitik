using System;
using Newtonsoft.Json;

namespace GP.DAL.Folketinget.Model.Øvrige
{
    public class SlettetMap : FolketingetModel
    {
        [JsonProperty("datatype")]
        public string Datatype { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("opdateringsdato")]
        public DateTime Opdateringsdato { get; set; }
    }
}