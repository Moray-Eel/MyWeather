using SQLite;
using SQLiteNetExtensions.Attributes;

namespace MyWeather.Infrastructure.Entities;

public class HourlyTemp
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    public double Temperature { get; set; }
    public DateTime DateTime { get; set; }

    [ForeignKey(typeof(WeatherInfo))]
    public int WeatherId { get; set; }
}