using ApplicationHandlers.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TemplateProject.Application.Abstractions.WeatherForecasts;

namespace TemplateProject.Blazor.Server.WeatherForecasts;

public static class WeatherForecastsContainer
{
    public static IServiceCollection AddWeatherForecasts(this IServiceCollection services)
    {
        services.AddQueryHandler<IGetWeatherForecastQueryHandler, GetWeatherForecastQuery, GetWeatherForecastResponse>(
            s => new LoggingGetWeatherForecastQueryHandler(
                decoratedHandler: new GetWeatherForecastQueryHandler(),
                loggerFactory: s.GetRequiredService<ILoggerFactory>()));
        
        return services;
    }
}