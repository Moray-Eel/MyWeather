namespace MyWeather.Infrastructure.Json;

public record City(int Id, string Name, string State, string Country, Coord Coord);

public record Coord(double Lon, double Lat);