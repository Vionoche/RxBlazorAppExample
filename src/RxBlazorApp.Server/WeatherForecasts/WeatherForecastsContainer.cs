using Microsoft.Extensions.DependencyInjection;
using ApplicationHandlers.DependencyInjection;
using Microsoft.Extensions.Logging;
using RxBlazorApp.Shared.WeatherForecasts;

namespace RxBlazorApp.Server.WeatherForecasts;

public static class WeatherForecastsContainer
{
    public static IServiceCollection AddWeatherForecasts(this IServiceCollection services)
    {
        services.AddQueryHandler<IGetWeatherForecastQueryHandler, GetWeatherForecastQuery, GetWeatherForecastResponse>(
            s => new LoggingWeatherForecastHandlers(
                decoratedHandler: new GetWeatherForecastQueryHandler(),
                loggerFactory: s.GetRequiredService<ILoggerFactory>()));
        
        return services;
    }
}