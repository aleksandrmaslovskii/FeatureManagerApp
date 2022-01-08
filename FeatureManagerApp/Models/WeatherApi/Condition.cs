using Newtonsoft.Json;

namespace FeatureManagerApp.Models.WeatherApi;

public class Condition
{
    [JsonProperty("text")]
    public string Text { get; set; }

    [JsonProperty("icon")]
    public string Icon { get; set; }

    [JsonProperty("code")]
    public long Code { get; set; }
}