using MyWeather.Application.Results;
using MyWeather.Infrastructure.Dto;
using MyWeather.Infrastructure.Repositories;
using MyWeather.Presentation.Constants;
using MyWeather.Presentation.Services;

namespace MyWeather.Presentation.ViewModels;

public sealed class InitAddCityViewModel(ICityRepository cityRepository, IPreferences preferences, IDialogService dialogService, 
    INavigationService navigation, IConnectivity connectivity, IGeolocationService geolocation, ICityManagementService cityManagementService) : AddCityBaseViewModel(cityRepository, dialogService)
{
    private readonly IDialogService _dialogService = dialogService;

    protected override async Task AddSelectedCity(CitySearchResultDto cityDto)
    {
        if(connectivity.NetworkAccess != NetworkAccess.Internet)
        {
            await _dialogService.OpenDialogAsync(Codes.NoInternetConnection);
            return;
        }

        var addCityResult = await cityManagementService.AddWithNewestWeather(cityDto.Id);
        if (addCityResult.IsSuccess)
        {
            preferences.Set(PresentationConstants.FocusedCity, cityDto.Id);
            await navigation.GoToAsync(nameof(MainPage));
            return;
        }
        if(addCityResult.Error?.Code == Codes.CityAlreadyExists)
        {
            await _dialogService.OpenDialogAsync(Codes.CityAlreadyExists);
            return;
        }
        await _dialogService.OpenDialogAsync(Codes.CriticalError);
    }

    protected override async Task AddLocatedCity()
    {
        if(connectivity.NetworkAccess != NetworkAccess.Internet)
        {
            await _dialogService.OpenDialogAsync(Codes.NoInternetConnection);
            return;
        }
        
        var location = await geolocation.GetLocationAsync(new GeolocationRequest());
        
        if (location.IsFailure)
        {
            await _dialogService.OpenDialogAsync(Codes.LocationServicesDisabled);
            return;
        }
        
        if(location.Value is null)
        {
            await _dialogService.OpenDialogAsync(Codes.GettingLocationFailed);
            return;
        }
        
        var addCityResult = await cityManagementService.AddWithNewestWeather(location.Value.Latitude, location.Value.Longitude);
        if (addCityResult.IsSuccess)
        {
            preferences.Set(PresentationConstants.FocusedCity, addCityResult.Value);
            await navigation.GoToAsync(nameof(MainPage));
            return;
        }
        if(addCityResult.Error?.Code == Codes.CityAlreadyExists)
        {
            await _dialogService.OpenDialogAsync(Codes.CityAlreadyExists);
            return;
        }
        await _dialogService.OpenDialogAsync(Codes.CriticalError);
        
    }
}