using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MyWeather.Presentation.Services;

namespace MyWeather.Presentation.ViewModels;

public partial class ContextMenuViewModel() : ObservableObject
{
    [RelayCommand]
    async Task GoToSettings()
    {
        //Unfortunately had to use a static class to navigate, since xaml in maui does not support DI method injections for 
        //commands in the viewmodel, since this is a content view I need to initialize it with a default constructor without DI,
        //so I had to use a static class to navigate
        await Shell.Current.GoToAsync(nameof(ManageCitiesPage));
    }
    [RelayCommand]
    async Task GoToMapView()
    {
        //Unfortunately had to use a static class to navigate, since xaml in maui does not support DI method injections for 
        //commands in the viewmodel, since this is a content view I need to initialize it with a default constructor without DI,
        //so I had to use a static class to navigate
        await Shell.Current.GoToAsync(nameof(MapPage));
    }
  
}