using MyWeather.Infrastructure.Entities;
using MyWeather.Infrastructure.Json;
using MyWeather.Infrastructure.Mappers;
using SQLite;
using City = MyWeather.Infrastructure.Entities.City;

namespace MyWeather.Infrastructure;

//Declare as singleton
public class MyWeatherDbContext
{
    private static SQLiteAsyncConnection? _connection;

    public async ValueTask EnsureInit()
    {
        if (_connection is not null)
            return;

        _connection = new SQLiteAsyncConnection(DatabaseConstants.DataBasePath);

        if (File.Exists(DatabaseConstants.DataBasePath))
            return;

        await _connection.CreateTableAsync<City>(CreateFlags.FullTextSearch4)
            .ConfigureAwait(false);
        await _connection.CreateTablesAsync(CreateFlags.None,
            typeof(SavedCity),
            typeof(WeatherInfo),
            typeof(HourlyTemp))
            .ConfigureAwait(false);

        var citiesFromJson = await CitiesReader.ReadFromFile()
            .ConfigureAwait(false);
        var cities = citiesFromJson.MapToEntity();

        await _connection.InsertAllAsync(cities)
            .ConfigureAwait(false);
    }

    public async ValueTask<SQLiteAsyncConnection?> Connection()
    {
        if (_connection is null)
            await EnsureInit().ConfigureAwait(false);

        return _connection;    
    }
}

