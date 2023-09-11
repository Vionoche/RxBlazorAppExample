using Microsoft.Extensions.DependencyInjection;
using ApplicationHandlers.DependencyInjection;
using RxBlazorApp.Shared.WeatherForecasts;

namespace RxBlazorApp.Server.WeatherForecasts;

public static class WeatherForecastsContainer
{
    public static IServiceCollection AddWeatherForecasts(this IServiceCollection services)
    {
        services.AddQueryHandler<IGetWeatherForecastQueryHandler, GetWeatherForecastQuery, GetWeatherForecastResponse, GetWeatherForecastQueryHandler>();
        
        return services;
    }
}