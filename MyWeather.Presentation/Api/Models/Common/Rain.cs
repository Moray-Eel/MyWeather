using Newtonsoft.Json;

namespace MyWeather.Presentation.Api.Models.Common;

public class Rain
{
    [JsonProperty("3h")]
    public double _3h { get; set; }
}

