using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BackgroundService.Scheduler.FuelApiResponseModels
{
    public class SeriesResponseModel
    {
        [JsonProperty("series_id")]
        public string SeriesId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("units")]
        public string Units { get; set; }

        [JsonProperty("f")]
        public string F { get; set; }

        [JsonProperty("unitsshort")]
        public string UnitsShort { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("copyright")]
        public string Copyright { get; set; }

        [JsonProperty("source")]
        public string Source { get; set; }

        [JsonProperty("iso3166")]
        public string Iso3166 { get; set; }

        [JsonProperty("geography")]
        public string Geography { get; set; }

        [JsonProperty("start")]
        public string Start { get; set; }

        [JsonProperty("end")]
        public string End { get; set; }

        [JsonProperty("updated")]
        public DateTime Updated { get; set; }

        [JsonProperty("data")]
        public JArray Data { get; set; }
    }
}
