using SQLite;
using SQLiteNetExtensions.Attributes;

namespace MyWeather.Infrastructure.Entities;

public class SavedCity
{
    [PrimaryKey]
    public int Id { get; set; }
    public DateTime SaveTime { get; set; }
    public string Name { get; set; }
    public string State { get; set; }
    public string Country { get; set; }
    
    [OneToOne(CascadeOperations = CascadeOperation.All)]
    public WeatherInfo WeatherInfo { get; set; }

    [ForeignKey(typeof(WeatherInfo))]
    public int WeatherId { get; set; }
}