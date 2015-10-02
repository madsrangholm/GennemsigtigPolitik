using System;
using Newtonsoft.Json;

namespace GP.DAL.Folketinget.Model.Dokument
{
    public class Tale : FolketingetModel
    {
        [JsonProperty("aktørid")]
        public int AktørId { get; set; }

        [JsonProperty("dagsordenspunktid")]
        public int DagsordenspunktId { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("mødeid")]
        public int MødeId { get; set; }

        [JsonProperty("opdateringsdato")]
        public DateTime Opdateringsdato { get; set; }

        [JsonProperty("sluttidspunkt")]
        public DateTime SlutTidspunkt { get; set; }

        [JsonProperty("starttidspunkt")]
        public DateTime StartTidspunkt { get; set; }

        [JsonProperty("taletype")]
        public string TaleType { get; set; }

        [JsonProperty("tekst")]
        public string Tekst { get; set; }

        [JsonProperty("videoid")]
        public int VideoId { get; set; }
    }
}