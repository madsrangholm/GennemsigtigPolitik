using System;
using Newtonsoft.Json;

namespace GP.DAL.Folketinget.Model.Øvrige
{
    public class TabelBeskrivelse : FolketingetModel
    {
        [JsonProperty("beskrivelse")]
        public string Beskrivelse { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("opdateringsdato")]
        public DateTime Opdateringsdato { get; set; }

        [JsonProperty("tabelnavn")]
        public string TabelNavn { get; set; }
    }
}