using System;
using Newtonsoft.Json;

namespace GP.DAL.Folketinget.Model.Møde
{
    public class Dagsordenspunkt : FolketingetModel
    {
        [JsonProperty("forhandling")]
        public string Forhandling { get; set; }

        [JsonProperty("forhandlingskode")]
        public string Forhandlingskode { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("kommentar")]
        public string Kommentar { get; set; }

        [JsonProperty("kørebemærkning")]
        public string Kørebemærkning { get; set; }

        [JsonProperty("mødeid")]
        public int MødeId { get; set; }

        [JsonProperty("nummer")]
        public string Nummer { get; set; }

        [JsonProperty("offentlighedskode")]
        public string Offentlighedskode { get; set; }

        [JsonProperty("opdateringsdato")]
        public DateTime Opdateringsdato { get; set; }

        [JsonProperty("sagstrinid")]
        public int? SagstrinId { get; set; }

        [JsonProperty("superid")]
        public int? SuperId { get; set; }

        [JsonProperty("titel")]
        public string Titel { get; set; }
    }
}