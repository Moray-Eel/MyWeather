using Microsoft.Maui.Storage;
using MyWeather.Infrastructure.Json;
using System.Text.Json;

namespace MyWeather.Infrastructure;

public static class CitiesReader
{
    public static async Task<IEnumerable<City>> ReadFromFile()
    {
        await using var stream = await FileSystem.OpenAppPackageFileAsync(DatabaseConstants.CitiesFileName)
            .ConfigureAwait(false);
        IEnumerable<City> cities = await JsonSerializer.DeserializeAsync<IEnumerable<City>>(stream, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        }).ConfigureAwait(false)
            ?? throw new InvalidOperationException("Failed to deserialize cities");

        return cities;
    }
}