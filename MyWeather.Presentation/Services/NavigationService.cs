namespace MyWeather.Presentation.Services;

public class NavigationService : INavigationService
{
    public Task GoToAsync(string route, IDictionary<string, object>? parameters = default)
    {
        return parameters is not null 
            ? Shell.Current.GoToAsync(route, true, parameters) 
            : Shell.Current.GoToAsync(route, true);
    }
}

public interface INavigationService
{
    public Task GoToAsync(string route, IDictionary<string, object>? parameters = default);
}

