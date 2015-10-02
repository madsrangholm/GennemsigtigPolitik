using System;
using Newtonsoft.Json;

namespace GP.DAL.Folketinget.Model.Dokument
{
    public class Nyhed : FolketingetModel
    {
        [JsonProperty("brødtekst")]
        public string Brødtekst { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("manchet")]
        public string Manchet { get; set; }

        [JsonProperty("opdateringsdato")]
        public DateTime Opdateringsdato { get; set; }

        [JsonProperty("sagstrinid")]
        public int SagstrinId { get; set; }

        [JsonProperty("slutdato")]
        public DateTime? Slutdato { get; set; }

        [JsonProperty("startdato")]
        public DateTime? Startdato { get; set; }

        [JsonProperty("titel")]
        public string Titel { get; set; }
    }
}