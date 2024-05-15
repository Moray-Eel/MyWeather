using MyWeather.Application.Results;

namespace MyWeather.Presentation.Services;

public class GeoLocationService : IGeolocationService
{
    public async Task<Result<Location?>> GetLastKnownLocationAsync()
    {
        try
        {
            return await Geolocation.GetLastKnownLocationAsync();

        }
        catch (Exception e)
        {
            return new Error("Error getting location", e.Message);
        }
    }

    public async Task<Result<Location?>> GetLocationAsync(GeolocationRequest request, CancellationToken cancelToken = default)
    {
        try
        {
            return await Geolocation.GetLocationAsync(request, cancelToken);
        }
        catch (Exception e)
        {
            return new Error("Error getting location", e.Message);
        }
    }

    public async Task<Result<bool>> StartListeningForegroundAsync(GeolocationListeningRequest request)
    {
        try
        {
            return await Geolocation.StartListeningForegroundAsync(request);
        }
        catch (Exception e)
        {
            return new Error("Error getting location", e.Message);
        }
    }

    public Result StopListeningForeground()
    {
        try
        {
            Geolocation.StopListeningForeground();
            return Result.Success();
        }
        catch (Exception e)
        {
            return new Error("Error getting location", e.Message);
        }
    }
}

public interface IGeolocationService
{
    public Task<Result<Location?>> GetLastKnownLocationAsync();

    public Task<Result<Location?>> GetLocationAsync(GeolocationRequest request,
        CancellationToken cancelToken = default);

    public Task<Result<bool>> StartListeningForegroundAsync(GeolocationListeningRequest request);

    public Result StopListeningForeground();

}