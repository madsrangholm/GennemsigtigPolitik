using System;
using Newtonsoft.Json;

namespace GP.DAL.Folketinget.Model.Møde
{
    public class Stemme : FolketingetModel
    {
        [JsonProperty("afstemningid")]
        public int AfstemningId { get; set; }

        [JsonProperty("aktørid")]
        public int AktørId { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("opdateringsdato")]
        public DateTime Opdateringsdato { get; set; }

        [JsonProperty("typeid")]
        public int TypeId { get; set; }
    }
}