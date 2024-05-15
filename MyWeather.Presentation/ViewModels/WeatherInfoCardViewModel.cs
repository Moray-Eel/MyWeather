using CommunityToolkit.Mvvm.ComponentModel;

namespace MyWeather.Presentation.ViewModels;

public sealed partial class WeatherInfoCardViewModel : ObservableObject
{
    [ObservableProperty] private string cloudiness = null!;
    [ObservableProperty] private string humidity = null!;
    [ObservableProperty] private string pressure = null!;
    [ObservableProperty] private string sunrise = null!;
    [ObservableProperty] private string sunset = null!;
    [ObservableProperty] private string visibility = null!;
    [ObservableProperty] private string windDirection = null!;
    [ObservableProperty] private string windSpeed = null!;
    [ObservableProperty] private string temperature = null!;
    public WeatherInfoCardViewModel()
    {

    }
}
