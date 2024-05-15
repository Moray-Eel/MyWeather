namespace MyWeather.Presentation.Api.Responses;

public class WeatherResponse
{
    public int Id { get; set; }
    public double Temp { get; set; }
    public int Dt { get; set; }
    public int  Sunrise { get; set; }
    public int Sunset { get; set; }
    public int Visibility { get; set; }
    public double LikeTemp { get; set; }
    public double MinTemp { get; set; }
    public double MaxTemp { get; set; }
    public int Pressure { get; set; }
    public int SeaLevel { get; set; }
    public int GroundLevel { get; set; }
    public int Humidity { get; set; }
    public double Speed { get; set; }
    public int Deg { get; set; }
    public double Gust { get; set; }
    public string Main { get; set; } = null!;
    public string Description { get; set; } = null!;
    public int Cloudiness { get; set; }
    public List<Hourly> Hourly { get; set; } = null!;
}