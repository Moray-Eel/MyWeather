using System.Net.Http.Json;
using MyWeather.Application.Results;
using MyWeather.Presentation.Api.Models.CurrentWeather;
using MyWeather.Presentation.Api.Models.HourlyTemperature;
using MyWeather.Presentation.Api.Responses;

namespace MyWeather.Presentation.Services;

public class WeatherService : IWeatherService
{
    private const string BaseUrl = "https://api.openweathermap.org/data/2.5/";
    private const string ApiKey = "d6b5ebf9e076028eef0ef407969a07cb";
    private string GetCurrentByLocation(double lat, double lon, string key) => $"weather?lat={lat}&lon={lon}&appid={key}&units=metric";
    private string GetHourlyByLocation(double lat, double lon, string key) => $"forecast?lat={lat}&lon={lon}&appid={key}&units=metric&cnt=10";
    private string GetCurrentWeatherById(int id, string key) => $"weather?id={id}&appid={key}&units=metric";
    private string GetHourlyTemperaturesById(int id, string key) => $"forecast?id={id}&appid={key}&units=metric&cnt=10";
    private readonly HttpClient _httpClient = new() { BaseAddress = new Uri(BaseUrl) };
   


    public async Task<Result<WeatherResponse>> GetByLocation(double latitude, double longitude)
    {
        try
        {
            var currentRequest = _httpClient.GetFromJsonAsync<CurrentWeather>(GetCurrentByLocation(
                latitude, longitude, ApiKey));
            var hourlyRequest = _httpClient.GetFromJsonAsync<HourlyTemperature>(GetHourlyByLocation(
                latitude, longitude, ApiKey));
            
            await Task.WhenAll(currentRequest, hourlyRequest);

            var current = (await currentRequest) ?? throw new NullReferenceException("Error while fetching data from the server.");
            var hourly = (await hourlyRequest) ?? throw new NullReferenceException("Error while fetching data from the server.");
            
            return MapToResponse(current, hourly);
        }
        catch (Exception e)
        {
            return new Error("Error while fetching data from the server.");
        }
    }

    public async Task<Result<WeatherResponse>> GetById(int id)
    {
        try
        {
            var currentRequest = _httpClient.GetFromJsonAsync<CurrentWeather>(GetCurrentWeatherById(
                id, ApiKey));
            var hourlyRequest = _httpClient.GetFromJsonAsync<HourlyTemperature>(
                GetHourlyTemperaturesById(
                    id, ApiKey));

            await Task.WhenAll(currentRequest, hourlyRequest);

            var current = (await currentRequest) ??
                          throw new NullReferenceException(
                              "Error while fetching data from the server.");
            var hourly = (await hourlyRequest) ??
                         throw new NullReferenceException(
                             "Error while fetching data from the server.");

            return MapToResponse(current, hourly);
        }
        catch (Exception e)
        {
            return new Error("Error while fetching data from the server.");
        }
    }

    private WeatherResponse MapToResponse(CurrentWeather current, HourlyTemperature hourly)
    {
        return new WeatherResponse()
        {
            Id = current.Id,
            Cloudiness = current.Clouds.All,
            Deg = current.Wind.Deg,
            Description = current.Weather.First().Description,
            LikeTemp = current.Main.Feels_like,
            GroundLevel = current.Main.Grnd_level,
            Gust = current.Wind.Gust,
            Humidity = current.Main.Humidity,
            Main = current.Weather.First().Main,
            Pressure = current.Main.Pressure,
            SeaLevel = current.Main.Sea_level,
            Speed = current.Wind.Speed,
            Temp = current.Main.Temp,
            MaxTemp = current.Main.Temp_max,
            MinTemp = current.Main.Temp_min,
            Visibility = current.Visibility,
            Dt = current.Dt,
            Sunrise = current.Sys.Sunrise,
            Sunset = current.Sys.Sunset,
            Hourly = hourly.List.Select(h => new Hourly()
            {
                Dt = h.Dt,
                Temp = h.Main.Temp,
               
            }).ToList()
        };
    }
}


public interface IWeatherService
{
    public Task<Result<WeatherResponse>> GetByLocation(double latitude, double longitude);
    public Task<Result<WeatherResponse>> GetById(int id);
}