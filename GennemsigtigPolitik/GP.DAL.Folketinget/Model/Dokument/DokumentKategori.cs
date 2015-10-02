using System;
using Newtonsoft.Json;

namespace GP.DAL.Folketinget.Model.Dokument
{
    public class DokumentKategori : FolketingetModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("kategori")]
        public string Kategori { get; set; }

        [JsonProperty("opdateringsdato")]
        public DateTime Opdateringsdato { get; set; }
    }
}