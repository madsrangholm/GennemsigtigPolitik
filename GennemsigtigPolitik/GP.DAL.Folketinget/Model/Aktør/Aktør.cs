using System;
using Newtonsoft.Json;

namespace GP.DAL.Folketinget.Model.Aktør
{
    public class Aktør : FolketingetModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("biografi")]
        public string Biografi { get; set; }

        [JsonProperty("fornavn")]
        public string Fornavn { get; set; }

        [JsonProperty("efternavn")]
        public string Efternavn { get; set; }

        [JsonProperty("gruppenavnkort")]
        public string GruppenavnKort { get; set; }

        [JsonProperty("navn")]
        public string Navn { get; set; }

        [JsonProperty("opdateringsdato")]
        public DateTime Opdateringsdato { get; set; }

        [JsonProperty("periodeid")]
        public int? PeriodeId { get; set; }

        [JsonProperty("startdato")]
        public DateTime? StartDato { get; set; }

        [JsonProperty("slutdato")]
        public DateTime? SlutDato { get; set; }

        [JsonProperty("typeid")]
        public int? TypeId { get; set; }
    }
}