using CommunityToolkit.Mvvm.ComponentModel;

namespace MyWeather.Presentation.ViewModels;

public partial class WeatherHeaderViewModel : ObservableObject
{
    [ObservableProperty] private string updatedAt;
}