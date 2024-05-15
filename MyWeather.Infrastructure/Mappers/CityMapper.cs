using MyWeather.Infrastructure.Dto;
using MyWeather.Infrastructure.Entities;
using MyWeather.Infrastructure.Json;
using Riok.Mapperly.Abstractions;
using City = MyWeather.Infrastructure.Entities.City;

namespace MyWeather.Infrastructure.Mappers;

[Mapper]
public static partial class CityMapper
{
    internal static IEnumerable<City> MapToEntity(this IEnumerable<Json.City> cities)
        => cities.Select(c => new City
        {
            Id = c.Id,
            Name = c.Name,
            State = c.State,
            Country = c.Country,
            Longitude = c.Coord.Lon,
            Latitude = c.Coord.Lat
        });
    
    public static partial List<CitySearchResultDto> ProjectToDto(this List<City> city);
}