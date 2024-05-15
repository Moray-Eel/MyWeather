using CommunityToolkit.Mvvm.ComponentModel;
using MyWeather.Presentation.Constants;

namespace MyWeather.Presentation.ViewModels;

public sealed class AppShellViewModel : ObservableObject
{
    public ShellContent CurrentItem { get; set; }
    public AppShellViewModel(IPreferences preferences)
    {
        Routing.RegisterRoute(nameof(ManageCitiesPage), typeof(ManageCitiesPage));
        Routing.RegisterRoute(nameof(MapPage), typeof(MapPage));
        Routing.RegisterRoute(nameof(AddCityPage), typeof(AddCityPage));
        if (preferences.ContainsKey(PresentationConstants.FocusedCity))
        {
            Routing.RegisterRoute(nameof(InitAddCityPage), typeof(InitAddCityPage));
            CurrentItem = new ShellContent
            {
                ContentTemplate = new DataTemplate(typeof(MainPage)),
                Route = nameof(MainPage),
            };
        }
        else {
            Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
            CurrentItem = new ShellContent
            {
                ContentTemplate = new DataTemplate(typeof(InitAddCityPage)),
                Route = nameof(InitAddCityPage),
                Title = "Add City"
            };
        }
    }
}