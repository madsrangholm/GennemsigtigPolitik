using System;
using Newtonsoft.Json;

namespace GP.DAL.Folketinget.Model.Møde
{
    public class Afstemning : FolketingetModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("kommentar")]
        public string Kommentar { get; set; }

        [JsonProperty("konklusion")]
        public string Konklusion { get; set; }

        [JsonProperty("mødeid")]
        public int MødeId { get; set; }

        [JsonProperty("nummer")]
        public int Nummer { get; set; }

        [JsonProperty("opdateringsdato")]
        public DateTime Opdateringsdato { get; set; }

        [JsonProperty("sagstrinid")]
        public int? SagstrinId { get; set; }

        [JsonProperty("typeid")]
        public int TypeId { get; set; }

        [JsonProperty("vedtaget")]
        public bool Vedtaget { get; set; }
    }
}