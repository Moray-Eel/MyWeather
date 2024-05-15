using Microsoft.Extensions.Logging;
using MyWeather.Infrastructure.Repositories;
using MyWeather.Presentation.Services;
using Shiny.Jobs;

namespace MyWeather.Presentation.Jobs;

public class UpdateCitiesWeatherJob(ILogger<UpdateCitiesWeatherJob> logger)  : IJob
{
    
    public Task Run(JobInfo jobInfo, CancellationToken cancelToken)
    {
       logger.LogInformation("xd");
       return Task.CompletedTask;
    }
}