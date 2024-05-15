using CommunityToolkit.Maui;
using Material.Components.Maui.Extensions;
using Microsoft.Extensions.Logging;
using Mopups.Hosting;
using MyWeather.Infrastructure;
using MyWeather.Infrastructure.Repositories;
using MyWeather.Presentation.Controls.Handlers;
using MyWeather.Presentation.Jobs;
using Shiny;
using MyWeather.Presentation.Services;
using MyWeather.Presentation.ViewModels;
using Sharpnado.MaterialFrame;
using SkiaSharp.Views.Maui.Controls.Hosting;
using The49.Maui.ContextMenu;

namespace MyWeather.Presentation;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder.Services.AddSingleton<AppShell>();
        builder.Services.AddSingleton<AppShellViewModel>();
        
        
        builder.Services.AddSingleton<MyWeatherDbContext>();
        builder.Services.AddTransient<MainPageViewModel>();
        builder.Services.AddTransient<InitPageViewModel>();
        builder.Services.AddTransient<InitAddCityViewModel>();
        builder.Services.AddTransient<SearchBarViewModel>();
        builder.Services.AddTransient<ContextMenuViewModel>();
        builder.Services.AddTransient<ManageCitiesPageViewModel>();
        builder.Services.AddTransient<TemperatureChartCardViewModel>();
        builder.Services.AddTransient<AddCityViewModel>();
        builder.Services.AddTransient<MapPageViewModel>();
        
        
        builder.Services.AddTransient<MainPage>();
        builder.Services.AddTransient<InitPage>();
        builder.Services.AddTransient<AddCityPage>();
        builder.Services.AddTransient<InitAddCityPage>();
        builder.Services.AddTransient<ManageCitiesPage>();
        builder.Services.AddTransient<MapPage>();
        
        builder.Services.AddSingleton<IWeatherService, WeatherService>();
        builder.Services.AddSingleton<INavigationService, NavigationService>();
        builder.Services.AddSingleton<INavigationService, NavigationService>();
        builder.Services.AddSingleton<ICityManagementService, CityManagementService>();
        builder.Services.AddSingleton<IGeolocationService, GeoLocationService>();
        builder.Services.AddSingleton<IDialogService, DialogService>();

        builder.Services.AddSingleton(Preferences.Default);
        builder.Services.AddSingleton(Connectivity.Current);
        
        builder.Services.AddTransient<ICityRepository, CityRepository>();
        builder.Services.AddTransient<ISavedCityRepository, SavedCityRepository>();
        
        builder
            .UseMauiApp<App>()
            .UseShiny()
            .ConfigureMopups()
            .UseMaterialComponents()
            .UseMauiCommunityToolkit()
            .UseContextMenu()
            .UseSharpnadoMaterialFrame(false)
            .UseSkiaSharp(true)
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });
        
        

        Handlers.RegisterHandlers();

#if DEBUG
        builder.Logging.AddDebug();
#endif

/*#if ANDROID
        builder.Services.AddJob(typeof(UpdateCitiesWeatherJob));
#endif*/

        return builder.Build();
    }
}