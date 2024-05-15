using Microsoft.Maui.Storage;

namespace MyWeather.Infrastructure;

internal static class DatabaseConstants
{
    internal const string CitiesFileName = "cities.list.json";
    internal const string DataBaseFileName = "MyWeather.db";
    internal static string DataBasePath => Path.Combine(FileSystem.AppDataDirectory, DataBaseFileName);
}