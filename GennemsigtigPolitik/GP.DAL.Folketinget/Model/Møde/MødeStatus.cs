﻿using System;
using Newtonsoft.Json;

namespace GP.DAL.Folketinget.Model.Møde
{
    public class MødeStatus : FolketingetModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("opdateringsdato")]
        public DateTime Opdateringsdato { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }
    }
}