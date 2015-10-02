using System;
using Newtonsoft.Json;

namespace GP.DAL.Folketinget.Model.Dokument
{
    public class Dokument : FolketingetModel
    {
        [JsonProperty("dagsordenudgavenummer")]
        public int? DagsordenUdgaveNummer { get; set; }

        [JsonProperty("dato")]
        public DateTime Dato { get; set; }

        [JsonProperty("frigivelsesdato")]
        public DateTime? Frigivelsesdato { get; set; }

        [JsonProperty("grundnotatstatus")]
        public string GrundnotatStatus { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("kategoriid")]
        public int KategoriId { get; set; }

        [JsonProperty("modtagelsesdato")]
        public DateTime? Modtagelsesdato { get; set; }

        [JsonProperty("offentlighedskode")]
        public string Offentlighedskode { get; set; }

        [JsonProperty("opdateringsdato")]
        public DateTime Opdateringsdato { get; set; }

        [JsonProperty("paragraf")]
        public string Paragraf { get; set; }

        [JsonProperty("paragrafnummer")]
        public string ParagrafNummer { get; set; }

        [JsonProperty("procedurenummer")]
        public string ProcedureNummer { get; set; }

        [JsonProperty("spørgsmålsid")]
        public int? SpørgsmålsId { get; set; }

        [JsonProperty("spørgsmålsordlyd")]
        public string Spørgsmålsordlyd { get; set; }

        [JsonProperty("spørgsmålstitel")]
        public string Spørgsmålstitel { get; set; }

        [JsonProperty("statusid")]
        public int StatusId { get; set; }

        [JsonProperty("titel")]
        public string Titel { get; set; }

        [JsonProperty("typeid")]
        public int TypeId { get; set; }
    }
}