using System.Collections.Generic;
using Newtonsoft.Json;

namespace BackgroundService.Scheduler.FuelApiResponseModels
{
    public class FuelApiResponseModel
    {
        [JsonProperty("series")]
        public IEnumerable<SeriesResponseModel> Series { get; set; }
    }
}
