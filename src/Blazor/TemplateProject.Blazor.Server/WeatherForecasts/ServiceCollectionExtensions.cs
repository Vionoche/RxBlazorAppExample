using ApplicationHandlers;
using ApplicationHandlers.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using TemplateProject.Application.Abstractions.WeatherForecasts;
using TemplateProject.Application.WeatherForecasts;

namespace TemplateProject.Blazor.Server.WeatherForecasts;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddWeatherForecastHandlers(this IServiceCollection services)
    {
        services
            .AddQueryHandler<IGetWeatherForecastQueryHandler,
                GetWeatherForecastQuery, GetWeatherForecastResponse, GetWeatherForecastQueryHandler>()
            .Decorate<IApplicationHandler<GetWeatherForecastQuery, GetWeatherForecastResponse>,
                GetWeatherForecastLoggingHandler>();
        
        return services;
    }
}