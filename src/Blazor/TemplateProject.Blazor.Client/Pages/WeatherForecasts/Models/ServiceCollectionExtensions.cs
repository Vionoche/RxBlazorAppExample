using ApplicationHandlers.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using TemplateProject.Application.Abstractions.WeatherForecasts;
using TemplateProject.Blazor.Client.Pages.WeatherForecasts.Handlers;

namespace TemplateProject.Blazor.Client.Pages.WeatherForecasts.Models;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddWeatherForecastComponents(this IServiceCollection services)
    {
        services
            .AddQueryHandler<IGetWeatherForecastQueryHandler, GetWeatherForecastQuery, GetWeatherForecastResponse, GetWeatherForecastHttpQueryHandler>();
        
        return services;
    }
}