using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MyWeather.Application.Results;
using MyWeather.Infrastructure.Dto;
using MyWeather.Infrastructure.Mappers;
using MyWeather.Infrastructure.Repositories;
using MyWeather.Presentation.Services;

namespace MyWeather.Presentation.ViewModels;

public abstract partial class AddCityBaseViewModel(ICityRepository cityRepository, IDialogService dialogService) : ObservableObject
{
    [ObservableProperty] private ObservableCollection<CitySearchResultDto>? _cities;
    [ObservableProperty] private bool _citiesNotEmpty;
    [RelayCommand]
    async Task Search(string query)
    {
        if(string.IsNullOrWhiteSpace(query))
        {
            Cities?.Clear();
            CitiesNotEmpty = false;
            return;
        }
        
        var cities = await cityRepository.GetByPrefix(query.Trim());
        if (cities.IsSuccess)
        {
            
            Cities = new ObservableCollection<CitySearchResultDto>(cities.Value.ProjectToDto());
            CitiesNotEmpty = Cities.Any();
        }
        else 
            await dialogService.OpenDialogAsync(Codes.CriticalError);
    }
    [RelayCommand]
    protected abstract Task AddSelectedCity(CitySearchResultDto cityDto);
    
    [RelayCommand]
    protected abstract Task AddLocatedCity();
}