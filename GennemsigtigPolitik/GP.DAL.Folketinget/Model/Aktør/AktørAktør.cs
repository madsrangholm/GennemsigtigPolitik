using System;
using Newtonsoft.Json;

namespace GP.DAL.Folketinget.Model.Aktør
{
    public class AktørAktør : FolketingetModel
    {
        [JsonProperty("fraaktørid")]
        public int FraAktørId { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("opdateringsdato")]
        public DateTime Opdateringsdato { get; set; }

        [JsonProperty("rolleid")]
        public int RolleId { get; set; }

        [JsonProperty("slutdato")]
        public DateTime? Slutdato { get; set; }

        [JsonProperty("startdato")]
        public DateTime? StartDato { get; set; }

        [JsonProperty("tilaktørid")]
        public int TilAktørId { get; set; }
    }
}