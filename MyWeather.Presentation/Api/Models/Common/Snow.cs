using Newtonsoft.Json;

namespace MyWeather.Presentation.Api.Models.Common;

public class Snow
{
    [JsonProperty("3h")]
    public double _3h { get; set; }
}