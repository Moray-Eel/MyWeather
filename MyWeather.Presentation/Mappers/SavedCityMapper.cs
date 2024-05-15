using System.Globalization;
using MyWeather.Infrastructure.Dto;
using MyWeather.Infrastructure.Entities;
using MyWeather.Presentation.Api.Responses;
using MyWeather.Presentation.Constants;
using MyWeather.Presentation.ViewModels;
using Riok.Mapperly.Abstractions;
using City = MyWeather.Infrastructure.Entities.City;

namespace MyWeather.Presentation.Mappers;

[Mapper]
public static partial class SavedCityMapper
{
    
    internal static IEnumerable<SavedCityDto> ProjectToDto(this IEnumerable<SavedCity> cities)
        => cities.Select(c => new SavedCityDto
        
            (c.Id,
            c.Name,
            c.Country,
            c.State,
            c.WeatherInfo.Description,
            c.WeatherInfo.Temp.ToString(CultureInfo.InvariantCulture))
        );
    
    internal static SavedCity MapToEntity(this City city, WeatherResponse weather)
        => new()
        {
            Id = city.Id,
            Name = city.Name,
            Country = city.Country,
            State = city.State,
            SaveTime = DateTimeOffset.FromUnixTimeSeconds(weather.Dt).DateTime,
            WeatherInfo = new WeatherInfo()
            {
                Condition = weather.Main,
                Cloudiness = weather.Cloudiness,
                Humidity = weather.Humidity,
                Description = weather.Description,
                Temp = weather.Temp.RoundToHalf(),
                ApparentTemp = weather.LikeTemp.RoundToHalf(),
                MaxTemp = weather.MaxTemp.RoundToHalf(),
                MinTemp = weather.MinTemp.RoundToHalf(),
                Pressure = weather.Pressure,
                Visibility = weather.Visibility,
                WindDirection = weather.Deg,
                WindSpeed = weather.Speed,
                Sunrise = DateTimeOffset.FromUnixTimeSeconds(weather.Sunrise).DateTime,
                Sunset = DateTimeOffset.FromUnixTimeSeconds(weather.Sunset).DateTime,
                Hourly = weather.Hourly.Select(h => new HourlyTemp
                {
                    DateTime = DateTimeOffset.FromUnixTimeSeconds(h.Dt).DateTime,
                    Temperature = h.Temp.RoundToHalf()
                }).ToList()
            }
        };
    
    internal static void MapWeather(this SavedCity city, WeatherResponse weather)
    {
        city.SaveTime = DateTimeOffset.FromUnixTimeSeconds(weather.Dt).DateTime;
        city.WeatherInfo = new WeatherInfo()
        {
            Condition = weather.Main,
            Cloudiness = weather.Cloudiness,
            Humidity = weather.Humidity,
            Description = weather.Description,
            Temp = weather.Temp.RoundToHalf(),
            ApparentTemp = weather.LikeTemp.RoundToHalf(),
            MaxTemp = weather.MaxTemp.RoundToHalf(),
            MinTemp = weather.MinTemp.RoundToHalf(),
            Pressure = weather.Pressure,
            Visibility = weather.Visibility,
            WindDirection = weather.Deg,
            WindSpeed = weather.Speed,
            Sunrise = DateTimeOffset.FromUnixTimeSeconds(weather.Sunrise).DateTime,
            Sunset = DateTimeOffset.FromUnixTimeSeconds(weather.Sunset).DateTime,
            Hourly = weather.Hourly.Select(h => new HourlyTemp
            {
                DateTime = DateTimeOffset.FromUnixTimeSeconds(h.Dt).DateTime,
                Temperature = h.Temp.RoundToHalf()
            }).ToList()
        };
    }

    internal static (WeatherSummaryCardViewModel, TemperatureChartCardViewModel,
        WeatherInfoCardViewModel, WeatherHeaderViewModel) ProjectToVm(this SavedCity city)
    {
        var tempCard = new TemperatureChartCardViewModel();

        city.WeatherInfo.Hourly
            .ForEach(h =>
                {
                    var date = h.DateTime;/*DateTimeOffset.FromUnixTimeSeconds(h.DateTime).ToLocalTime().ToString("dd/MM hh:mm tt");*/
                    var value = h.Temperature;
                    tempCard.Values.Add(value);
                    tempCard.Labels.Add(date.ToLocalTime().ToString("hh:mm tt dd/MM"));
                }
            );        
        return
        (
            new WeatherSummaryCardViewModel()
            {
                City = city.Name,
                Condition = city.WeatherInfo.Condition,
                IconSource = IconPaths.GetPath(city.WeatherInfo.Condition),
                Temperature = city.WeatherInfo.Temp.ToString(CultureInfo.InvariantCulture),
                Description = city.WeatherInfo.Description,
            },
            tempCard,
            new WeatherInfoCardViewModel
            {
                Cloudiness = city.WeatherInfo.Cloudiness.ToString(),
                Humidity = city.WeatherInfo.Humidity.ToString(),
                Pressure = city.WeatherInfo.Pressure.ToString(),
                Visibility = city.WeatherInfo.Visibility.ToString(),
                WindDirection = city.WeatherInfo.WindDirection.ToString(),
                WindSpeed = city.WeatherInfo.WindSpeed.ToString(CultureInfo.InvariantCulture),
                Sunrise = city.WeatherInfo.Sunrise.ToLocalTime().ToString("hh:mm tt "),
                Sunset = city.WeatherInfo.Sunset.ToLocalTime().ToString("hh:mm tt"),
                Temperature = city.WeatherInfo.ApparentTemp.ToString(CultureInfo.InvariantCulture),
            },
            new WeatherHeaderViewModel
            {
                UpdatedAt = city.SaveTime.ToLocalTime().ToString("hh:mm tt dd/MM") /*DateTimeOffset.FromUnixTimeSeconds(city.SaveTime).ToLocalTime().ToString("HH:mm MMM yy" )*/
            }
        );
    }
    
    private static double RoundToHalf(this double temp)
    {
        var value = Math.Round(temp * 2, MidpointRounding.AwayFromZero) / 2;
        if (value == double.NegativeZero)
            value = 0;
        return value;
    }
}     