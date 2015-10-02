using System;
using Newtonsoft.Json;

namespace GP.DAL.Folketinget.Model.Øvrige
{
    public class Slettet : FolketingetModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("objektid")]
        public int ObjektId { get; set; }

        [JsonProperty("opdateringsdato")]
        public DateTime Opdateringsdato { get; set; }

        [JsonProperty("slettetmapid")]
        public int SlettetMapId { get; set; }
    }
}