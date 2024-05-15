using MyWeather.Application.Results;
using MyWeather.Infrastructure.Entities;
using SQLiteNetExtensionsAsync.Extensions;

namespace MyWeather.Infrastructure.Repositories;

public interface ISavedCityRepository
{
    Task<Result> Add(SavedCity savedCity);
    Task<Result<SavedCity?>> GetById(int id);
    Task<Result<SavedCity?>> GetById(int id, bool recursive);
    Task<Result> Update(SavedCity savedCity);
    Task<Result> Delete(int id);
    Task<Result<List<SavedCity>>> GetAllExcept(int id);
}

public class SavedCityRepository(MyWeatherDbContext context) : ISavedCityRepository
{
    public async Task<Result> Add(SavedCity savedCity)
    {
        var connection = await context.Connection();
        try
        {
            await connection.InsertWithChildrenAsync(savedCity, true);
            return Result.Success();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new Error("Failed to add city", "Failed to add city");
        }
        
    }
    
    public async Task<Result<SavedCity?>> GetById(int id)
    {
        var connection = await context.Connection();

        try
        {
            var city = await connection.FindAsync<SavedCity>(id);
            return city;
        }
        catch (Exception e)
        {
            return new Error("City does not exist", "City does not exist");
        }
    }

    public async Task<Result<SavedCity?>> GetById(int id, bool recursive)
    {
        var connection = await context.Connection();
        try
        {
            return await connection.GetWithChildrenAsync<SavedCity>(id, recursive);
        }
        catch (Exception e)
        {
            return new Error("Error during fetching city", "Error during fetching city");
        }
    }
    
    
    public async Task<Result> Update(SavedCity savedCity)
    {
        var connection = await context.Connection();
        await connection.InsertOrReplaceWithChildrenAsync(savedCity, true);
        return Result.Success();
    }

    public async Task<Result> Delete(int id)
    {
        var connection = await context.Connection();
        var savedCity = await connection.GetWithChildrenAsync<SavedCity>(id, true);
        await connection.DeleteAsync(savedCity, true);
        return Result.Success();
    }

    public async Task<Result<List<SavedCity>>> GetAllExcept(int id)
    {
        var connection = await context.Connection();
        return await connection.GetAllWithChildrenAsync<SavedCity>(c => c.Id != id, true);
    }
}