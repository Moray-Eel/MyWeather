using MyWeather.Presentation.Api.Models.Common;

namespace MyWeather.Presentation.Api.Models.CurrentWeather;

//Api response return weather data every 3 hours. Named hourly for simplicity.
public class CurrentWeather
{
    public int Id { get; set; }
    public Main Main { get; set; } = null!;
    public Weather[] Weather { get; set; } = null!;
    public int Visibility { get; set; }
    public Wind Wind { get; set; } = null!;
    public Clouds Clouds { get; set; } = null!;
    public int Dt { get; set; }
    public Rain Rain { get; set; } = null!;
    public Sys Sys { get; set; } = null!;
}