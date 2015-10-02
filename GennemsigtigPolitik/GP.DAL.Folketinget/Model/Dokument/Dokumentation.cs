using System;
using Newtonsoft.Json;

namespace GP.DAL.Folketinget.Model.Dokument
{
    public class Dokumentation : FolketingetModel
    {
        [JsonProperty("dokumentid")]
        public int DokumentId { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("nyhedsid")]
        public int NyhedsId { get; set; }

        [JsonProperty("opdateringsdato")]
        public DateTime Opdateringsdato { get; set; }

        [JsonProperty("videoid")]
        public int VideoId { get; set; }
    }
}