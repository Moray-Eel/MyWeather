using System.Runtime.InteropServices.JavaScript;
using MyWeather.Application.Results;
using MyWeather.Infrastructure.Entities;
using MyWeather.Infrastructure.Repositories;
using MyWeather.Presentation.Api.Responses;
using MyWeather.Presentation.Mappers;

namespace MyWeather.Presentation.Services;

public interface ICityManagementService
{
    Task<Result<SavedCity>> GetWithNewestWeatherById(int id);    
    Task<Result<int>> AddWithNewestWeather(double latitude, double longitude);
    Task<Result> AddWithNewestWeather(int id);
}

public class CityManagementService(IWeatherService weatherService, ICityRepository cityRepository, ISavedCityRepository savedCityRepository) : ICityManagementService
{
    public async Task<Result<SavedCity>> GetWithNewestWeatherById(int id)
    {
        var weather = await weatherService.GetById(id);
        var city = await weather.OnSuccess(() => cityRepository.GetById(id));
        var savedCity = city.OnSuccess<City, SavedCity>(c => c.MapToEntity(weather.Value));
        var update = await savedCity.OnSuccess(savedCityRepository.Update);
        return update.OnSuccess(() => savedCity);
    }

  
    public async Task<Result<int>> AddWithNewestWeather(double latitude, double longitude)
    {
        var weather = await weatherService.GetByLocation(latitude, longitude);
        var cityId = weather.Value.Id;
        
        var savedCity = await weather.OnSuccess(() => savedCityRepository.GetById(cityId));
        
        if(savedCity is {IsSuccess: true, Value: not null})
            return Errors.CityAlreadyExists;
        
        var city = await savedCity.OnSuccess(() => cityRepository.GetById(weather.Value.Id));
        var add = await city.OnSuccess<City, SavedCity>(c => c.MapToEntity(weather.Value))
            .OnSuccess(savedCityRepository.Add);

        return add.OnSuccess<int>(() => cityId);
    }

    public async Task<Result> AddWithNewestWeather(int id)
    {
        var savedCity = await savedCityRepository.GetById(id);
        
        if(savedCity is {IsSuccess: true, Value: not null})
            return Errors.CityAlreadyExists;
        
        var weather = await savedCity.OnSuccess(() =>  weatherService.GetById(id));
        var city = await weather.OnSuccess(() =>  cityRepository.GetById(id));
        
        return await city.OnSuccess<City, SavedCity>(c => c.MapToEntity(weather.Value))
            .OnSuccess(savedCityRepository.Add);
    }
}