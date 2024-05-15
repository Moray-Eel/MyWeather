namespace MyWeather.Infrastructure.Dto;


public record SavedCityDto(
    int Id,
    string Name,
    string State,
    string Country,
    string Description,
    string Temperature);
