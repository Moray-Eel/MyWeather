using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MyWeather.Infrastructure.Repositories;
using MyWeather.Presentation.Constants;

namespace MyWeather.Presentation.ViewModels;

public partial class MapPageViewModel(IPreferences preferences, ICityRepository cityRepository) : ObservableObject
{
    [ObservableProperty] private string _source = string.Empty; 
    private string path =
        "https://www.meteoblue.com/en/weather/maps#coords=3.04/30.87/19.99&amp;map=windAnimation~rainbow~auto~10%20m%20above%20gnd~none";

    [RelayCommand]
    private async Task OnAppearing()
    {
        var cityId = preferences.Get(PresentationConstants.FocusedCity, 0);
        var city = await  cityRepository.GetById(cityId);
        if (city.IsSuccess && city.Value != null)
        {
            Source = GetSource(city.Value.Latitude, city.Value.Longitude);
        }
    }
    private string GetSource(double lat, double lon)
    {
        return $"https://www.meteoblue.com/en/weather/maps#coords=8/{lat}/{lon}&amp;map=windAnimation~rainbow~auto~10%20m%20above%20gnd~none";
    }
}