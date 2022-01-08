using Newtonsoft.Json;

namespace FeatureManagerApp.Models.WeatherApi
{
    public class Response
    {
        [JsonProperty("location")]
        public Location Location { get; set; }

        [JsonProperty("current")]
        public Current Current { get; set; }
    }
}
