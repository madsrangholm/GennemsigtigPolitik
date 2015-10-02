using System;
using Newtonsoft.Json;

namespace GP.DAL.Folketinget.Model.Sag
{
    public class Aktstykke : FolketingetModel
    {
        [JsonProperty("afgørelse")]
        public string Afgørelse { get; set; }

        [JsonProperty("afgørelsesdato")]
        public DateTime Afgørelsesdato { get; set; }

        [JsonProperty("afgørelsesresultatkode")]
        public string AfgørelsesresultatKode { get; set; }

        [JsonProperty("afstemningskonklusion")]
        public string Afstemningskonklusion { get; set; }

        [JsonProperty("baggrundsmateriale")]
        public string Baggrundsmateriale { get; set; }

        [JsonProperty("begrundelse")]
        public string Begrundelse { get; set; }

        [JsonProperty("deltundersagid")]
        public int DeltUnderSagId { get; set; }

        [JsonProperty("fremsatundersagid")]
        public int FremsatUnderSagId { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("kategoriid")]
        public int KategoriId { get; set; }

        [JsonProperty("lovnummer")]
        public string Lovnummer { get; set; }

        [JsonProperty("lovnummerdato")]
        public DateTime Lovnummerdato { get; set; }

        [JsonProperty("nummer")]
        public string Nummer { get; set; }

        [JsonProperty("nummernumerisk")]
        public string NummerNumerisk { get; set; }

        [JsonProperty("nummerpostfix")]
        public string NummerPostfix { get; set; }

        [JsonProperty("nummerprefix")]
        public string NummerPrefix { get; set; }

        [JsonProperty("offentlighedskode")]
        public string Offentlighedskode { get; set; }

        [JsonProperty("opdateringsdato")]
        public DateTime Opdateringsdato { get; set; }

        [JsonProperty("paragraf")]
        public string Paragraf { get; set; }

        [JsonProperty("paragrafnummer")]
        public int ParagrafNummer { get; set; }

        [JsonProperty("periodeid")]
        public int PeriodeId { get; set; }

        [JsonProperty("resume")]
        public string Resume { get; set; }

        [JsonProperty("retsinformationsurl")]
        public string Retsinformationsurl { get; set; }

        [JsonProperty("rådsmødedato")]
        public DateTime Rådsmødedato { get; set; }

        [JsonProperty("statsbudgetsag")]
        public bool StatsbudgetSag { get; set; }

        [JsonProperty("statusid")]
        public int StatusId { get; set; }

        [JsonProperty("titel")]
        public string Titel { get; set; }

        [JsonProperty("titelkort")]
        public string Titelkort { get; set; }

        [JsonProperty("typeid")]
        public int TypeId { get; set; }
    }
}