using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TemplateProject.Application.Abstractions.WeatherForecasts;
using TemplateProject.WeatherForecasts;

namespace TemplateProject.Blazor.Server.WeatherForecasts;

public class GetWeatherForecastQueryHandler : IGetWeatherForecastQueryHandler
{
    public Task<GetWeatherForecastResponse> Handle(GetWeatherForecastQuery request, CancellationToken cancellationToken)
    {
        var forecasts = Enumerable.Range(1, 5)
            .Select(index => WeatherForecast.Create(
                date: DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                temperatureC: Random.Shared.Next(-20, 55),
                summary: Summaries[Random.Shared.Next(Summaries.Length)]));

        var models = forecasts
            .Select(forecast => new WeatherForecastModel(
                forecast.Date,
                forecast.TemperatureC,
                forecast.TemperatureF,
                forecast.Summary))
            .ToList();

        return Task.FromResult(new GetWeatherForecastResponse(models));
    }
    
    private static readonly string[] Summaries = 
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };
}