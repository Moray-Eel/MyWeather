using CommunityToolkit.Mvvm.ComponentModel;

namespace MyWeather.Presentation.ViewModels;

public sealed partial class WeatherSummaryCardViewModel : ObservableObject
{
    [ObservableProperty] private string iconSource = null!;
    [ObservableProperty] private string city = null!;
    [ObservableProperty] private string description = null!;
    [ObservableProperty] private string temperature = null!;
    [ObservableProperty] private string condition = null!; // Main property in WeatherResponse

    public WeatherSummaryCardViewModel()
    {
        
    }
}