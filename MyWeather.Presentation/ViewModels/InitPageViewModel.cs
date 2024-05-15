using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MyWeather.Infrastructure;

namespace MyWeather.Presentation.ViewModels;

public sealed partial class InitPageViewModel(MyWeatherDbContext context, AppShell appShell) : ObservableObject
{
    [RelayCommand]
    private async Task OnAppearing()
    {
        await context.EnsureInit();
        Microsoft.Maui.Controls.Application.Current.MainPage = appShell;
    }
}
