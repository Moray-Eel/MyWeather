using SQLite;
using SQLiteNetExtensions.Attributes;

namespace MyWeather.Infrastructure.Entities;

public class WeatherInfo
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    public string Condition { get; set; }
    public string Description { get; set; }

    public int Visibility { get; set; }

    public int Cloudiness { get; set; }

    public double WindSpeed { get; set; }

    public int WindDirection { get; set; }

    public double Temp { get; set; }

    public double ApparentTemp { get; set; }

    public double MinTemp { get; set; }

    public double MaxTemp { get; set; }

    public int Pressure { get; set; }

    public int Humidity { get; set; }

    public DateTime Sunrise { get; set; }

    public DateTime Sunset { get; set; }

    [OneToMany(CascadeOperations = CascadeOperation.All)]
    public List<HourlyTemp> Hourly { get; set; }
}