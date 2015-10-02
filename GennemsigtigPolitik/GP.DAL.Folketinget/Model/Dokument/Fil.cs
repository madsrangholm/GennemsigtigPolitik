using System;
using Newtonsoft.Json;

namespace GP.DAL.Folketinget.Model.Dokument
{
    public class Fil : FolketingetModel
    {
        [JsonProperty("dokumentId")]
        public int DokumentId { get; set; }

        [JsonProperty("dokumentoffentlighedskode")]
        public string DokumentOffentlighedskode { get; set; }

        [JsonProperty("dokumentstatus")]
        public string DokumentStatus { get; set; }

        [JsonProperty("filurl")]
        public string FilUrl { get; set; }

        [JsonProperty("format")]
        public string Format { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("opdateringsdato")]
        public DateTime Opdateringsdato { get; set; }

        [JsonProperty("titel")]
        public string Titel { get; set; }

        [JsonProperty("variantkode")]
        public string VariantKode { get; set; }

        [JsonProperty("versionsdato")]
        public DateTime Versionsdato { get; set; }
    }
}