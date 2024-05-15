namespace MyWeather.Application.Results;

public static class Errors
{
    public static Error CityAlreadyExists = new Error(Codes.CityAlreadyExists, "The city you are trying to add already exists in the list.");
    public static Error NoInternetConnection = new Error(Codes.NoInternetConnection, "Please check your internet connection and try again.");
    public static Error LocationPermissionDenied = new Error(Codes.LocationPermissionDenied, "Please enable location permissions to use this feature.");
    public static Error LocationServicesDisabled = new Error(Codes.LocationServicesDisabled, "Please enable location services to use this feature.");
    public static Error LocationFailed = new Error(Codes.GettingLocationFailed, "We were unable to locate you.");

}
public static class Codes
{
    public const string CityAlreadyExists = "City already exists";
    public const string NoInternetConnection = "No internet connection";
    public const string LocationPermissionDenied = "Location permission denied";
    public const string LocationServicesDisabled = "Location services disabled";
    public const string GettingLocationFailed = "Getting location failed";
    public const string CriticalError = "Critical error occured";
}
