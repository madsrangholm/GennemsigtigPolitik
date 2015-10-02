using System;
using Newtonsoft.Json;

namespace GP.DAL.Folketinget.Model.Dokument
{
    public class Omtryk : FolketingetModel
    {
        [JsonProperty("begrundelse")]
        public string Begrundelse { get; set; }

        [JsonProperty("dato")]
        public DateTime Dato { get; set; }

        [JsonProperty("dokumentid")]
        public int DokumentId { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("opdateringsdato")]
        public DateTime Opdateringsdato { get; set; }
    }
}