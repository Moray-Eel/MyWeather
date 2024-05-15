using System.Collections.ObjectModel;
using CommunityToolkit.Maui.Core.Extensions;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MyWeather.Application.Results;
using MyWeather.Infrastructure.Dto;
using MyWeather.Infrastructure.Repositories;
using MyWeather.Presentation.Constants;
using MyWeather.Presentation.Mappers;
using MyWeather.Presentation.Services;

namespace MyWeather.Presentation.ViewModels;

public sealed partial class ManageCitiesPageViewModel(IPreferences preferences, ISavedCityRepository savedCityRepository,
    INavigationService navigation, IDialogService dialogService) : ObservableObject
{
    [ObservableProperty] private ObservableCollection<SavedCityDto> savedCities = new();
    [RelayCommand]
    private async Task OnAppearing()
    {
        var focusedCityId = preferences.Get(PresentationConstants.FocusedCity, 0);
        
        if(focusedCityId == 0)
            throw new InvalidOperationException("City ID is not set");

        var cities = await savedCityRepository.GetAllExcept(focusedCityId).ConfigureAwait(false);
        
        if (cities.IsSuccess)
        {
            SavedCities = new ObservableCollection<SavedCityDto>(cities.Value.ProjectToDto());
        }
        else
        {
            await dialogService.OpenDialogAsync(Codes.CriticalError);
        }

    }
    
    [RelayCommand]
    private async Task DeleteCity(SavedCityDto savedCity)
    {
        await savedCityRepository.Delete(savedCity.Id);
        SavedCities.Remove(savedCity);
    }
    
    [RelayCommand]
    private async Task NavigateToAddCity()
    {
        await navigation.GoToAsync(nameof(AddCityPage));
    }
    
    [RelayCommand]
    private async Task FocusCity(int cityId)
    {
        preferences.Set(PresentationConstants.FocusedCity, cityId);
        await navigation.GoToAsync("..");
    }
}