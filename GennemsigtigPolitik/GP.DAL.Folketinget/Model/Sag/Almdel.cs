using System;
using Newtonsoft.Json;

namespace GP.DAL.Folketinget.Model.Sag
{
    public class Almdel : FolketingetModel
    {
        [JsonProperty("afgørelse")]
        public string Afgørelse { get; set; }

        [JsonProperty("afgørelsesdato")]
        public DateTime AfgørelsesDato { get; set; }

        [JsonProperty("afgørelsesresultatkode")]
        public string AfgørelsesResultatKode { get; set; }

        [JsonProperty("afstemningskonklusion")]
        public string Afstemningskonklusion { get; set; }

        [JsonProperty("baggrundsmateriale")]
        public string Baggrundsmateriale { get; set; }

        [JsonProperty("begrundelse")]
        public string Begrundelse { get; set; }

        [JsonProperty("deltundersagid")]
        public int DeltUndersagId { get; set; }

        [JsonProperty("fremsatundersagid")]
        public int FremsatUndersagId { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("kategoriid")]
        public int KategoriId { get; set; }

        [JsonProperty("lovnummer")]
        public string Lovnummer { get; set; }

        [JsonProperty("lovenummerdato")]
        public DateTime LovnummerDato { get; set; }

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
        public DateTime OpdateringsDato { get; set; }

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
        public DateTime RådsmødeDato { get; set; }

        [JsonProperty("statsbudgetsag")]
        public bool StatsbudgetSag { get; set; }

        [JsonProperty("statusid")]
        public int StatusId { get; set; }

        [JsonProperty("titel")]
        public string Titel { get; set; }

        [JsonProperty("titelkort")]
        public string TitelKort { get; set; }

        [JsonProperty("typeid")]
        public int TypeId { get; set; }
    }
}