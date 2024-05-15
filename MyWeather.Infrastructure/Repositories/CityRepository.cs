using MyWeather.Application.Results;
using MyWeather.Infrastructure.Dto;
using MyWeather.Infrastructure.Entities;

namespace MyWeather.Infrastructure.Repositories;

public interface ICityRepository
{
    Task<Result<List<City>>> GetByPrefix(string prefix);
    Task<Result<City>> GetById(int id);
}

public class CityRepository(MyWeatherDbContext context) : ICityRepository
{
    private const string GetByPrefixQuery =
        $"SELECT * FROM {nameof(City)} WHERE Name MATCH ? LIMIT 100";
  
    public async Task<Result<List<City>>> GetByPrefix(string prefix)
    {
        var connection = await context.Connection();
        return await connection.QueryAsync<City>(GetByPrefixQuery, $"{prefix}*");
    }

    public async Task<Result<City>> GetById(int id)
    {
        var connection = await context.Connection();
        return await connection.GetAsync<City>(x => x.Id == id);
    }
}