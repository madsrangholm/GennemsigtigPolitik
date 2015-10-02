using System;
using Newtonsoft.Json;

namespace GP.DAL.Folketinget.Model.Møde
{
    public class Møde : FolketingetModel
    {
        [JsonProperty("dagsordenurl")]
        public string DagsordenUrl { get; set; }

        [JsonProperty("dato")]
        public DateTime Dato { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("lokale")]
        public string Lokale { get; set; }

        [JsonProperty("mødestatusid")]
        public int MødestatusId { get; set; }

        [JsonProperty("mødetypeid")]
        public int MødetypeId { get; set; }

        [JsonProperty("nummer")]
        public string Nummer { get; set; }

        [JsonProperty("offentlighedskode")]
        public string Offentlighedskode { get; set; }

        [JsonProperty("opdateringsdato")]
        public DateTime Opdateringsdato { get; set; }

        [JsonProperty("periodeid")]
        public int PeriodeId { get; set; }

        [JsonProperty("starttidsbemærkning")]
        public string Starttidsbemærkning { get; set; }

        [JsonProperty("titel")]
        public string Titel { get; set; }
    }
}