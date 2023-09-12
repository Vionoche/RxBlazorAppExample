using ApplicationHandlers.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using RxBlazorApp.Shared.WeatherForecasts;

namespace RxBlazorApp.Client.Pages.WeatherForecasts.Models;

public static class WeatherForecastsClientContainer
{
    public static IServiceCollection AddWeatherForecastComponents(this IServiceCollection services)
    {
        services
            .AddQueryHandler<IGetWeatherForecastQueryHandler, GetWeatherForecastQuery, GetWeatherForecastResponse, HttpGetWeatherForecastQueryHandler>();
        
        return services;
    }
}