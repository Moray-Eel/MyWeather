using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MyWeather.Application.Results;
using MyWeather.Presentation.Constants;
using MyWeather.Presentation.Controls.Popups;
using MyWeather.Presentation.Mappers;
using MyWeather.Presentation.Services;

namespace MyWeather.Presentation.ViewModels;

public sealed partial class MainPageViewModel(IPreferences preferences, IConnectivity connectivity,
    ICityManagementService cityManagementService, IDialogService dialogService): ObservableObject
{
    [ObservableProperty] WeatherInfoCardViewModel _weatherInfoCard = null!;
    [ObservableProperty] TemperatureChartCardViewModel _temperatureChartCard = null!;
    [ObservableProperty] WeatherSummaryCardViewModel _weatherSummaryCard = null!;
    [ObservableProperty] WeatherHeaderViewModel _weatherHeaderViewModel = null!;
    
    [ObservableProperty] bool _isRefreshing;
    [RelayCommand]
    private async Task RefreshWeatherData()
    {
        IsRefreshing = true;
        var cityId = preferences.Get(PresentationConstants.FocusedCity, 0);
        
        if(connectivity.NetworkAccess != NetworkAccess.Internet)
        {
            IsRefreshing = false;
            await dialogService.OpenDialogAsync(Codes.NoInternetConnection);
            return;
        }
        
        var savedCity = await cityManagementService.GetWithNewestWeatherById(cityId);
        if(savedCity.IsSuccess)
            (WeatherSummaryCard, TemperatureChartCard, WeatherInfoCard, WeatherHeaderViewModel ) = savedCity.Value.ProjectToVm();
        else
            await dialogService.OpenDialogAsync(Codes.CriticalError);
        
        IsRefreshing = false;
    }
    [RelayCommand]
    private async Task OnAppearing()
    {
        IsRefreshing = true;
        var cityId = preferences.Get(PresentationConstants.FocusedCity, 0);
        
        
        if(connectivity.NetworkAccess != NetworkAccess.Internet)
        {
            IsRefreshing = false;
            await dialogService.OpenDialogAsync(Codes.NoInternetConnection);
            return;
        }

        var savedCity = await cityManagementService.GetWithNewestWeatherById(cityId);
        if(savedCity.IsSuccess)
            (WeatherSummaryCard, TemperatureChartCard, WeatherInfoCard, WeatherHeaderViewModel) = savedCity.Value.ProjectToVm();
        else
            await dialogService.OpenDialogAsync(Codes.CriticalError);
        IsRefreshing = false;
    }
    [RelayCommand]
    private async Task SeeExtendedForecast()
    {
        var cityId = preferences.Get(PresentationConstants.FocusedCity, 0);
        await Browser.Default.OpenAsync($"https://openweathermap.org/city/{cityId}", BrowserLaunchMode.SystemPreferred);
    }
}
