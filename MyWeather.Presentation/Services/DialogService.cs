using Material.Components.Maui;
using MyWeather.Application.Results;
using MyWeather.Presentation.Controls.Popups;
using MyWeather.Presentation.ViewModels;

namespace MyWeather.Presentation.Services;

public class DialogService : IDialogService
{
    public async Task OpenDialogAsync(string code)
    {
        var currentPage = Microsoft.Maui.Controls.Application.Current.MainPage;
        Popup dialog = code switch
        {
            Codes.CityAlreadyExists => new CityAlreadyExistsPopup(),
            Codes.NoInternetConnection => new NoInternetPopup(),
            Codes.LocationPermissionDenied => new LocationPermisionDeniedPopup(),
            Codes.LocationServicesDisabled => new LocationDisabledPopup(),

            _ => new CriticalErrorPopup(),
        };
        dialog.Parent = currentPage;
        await dialog.ShowAtAsync(currentPage);
    }
}

public interface IDialogService
{
    public Task OpenDialogAsync(string code);
}