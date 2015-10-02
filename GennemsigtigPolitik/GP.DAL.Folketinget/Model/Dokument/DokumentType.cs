using System;
using Newtonsoft.Json;

namespace GP.DAL.Folketinget.Model.Dokument
{
    public class DokumentType : FolketingetModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("opdateringsdato")]
        public DateTime Opdateringsdato { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }
}