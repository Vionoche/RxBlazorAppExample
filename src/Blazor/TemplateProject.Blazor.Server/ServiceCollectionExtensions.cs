using ApplicationHandlers;
using ApplicationHandlers.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using TemplateProject.Application.Abstractions.Authentication;
using TemplateProject.Application.Abstractions.WeatherForecasts;
using TemplateProject.Application.WeatherForecasts;
using TemplateProject.Blazor.Server.Authentication;
using TemplateProject.Blazor.Server.Logging;

namespace TemplateProject.Blazor.Server;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddHandlers(this IServiceCollection services)
    {
        return services
            .AddAuthenticationHandlers()
            .AddWeatherForecastHandlers();
    }
    
    private static IServiceCollection AddAuthenticationHandlers(this IServiceCollection services)
    {
        return services
            .AddQueryHandler<GetAuthenticatedUserQuery, GetAuthenticatedUserResponse, GetAuthenticatedUserHandler>();
    }
    private static IServiceCollection AddWeatherForecastHandlers(this IServiceCollection services)
    {
        return services
            .AddQueryHandler<GetWeatherForecastQuery, GetWeatherForecastResponse, GetWeatherForecastQueryHandler>()
            .Decorate<IApplicationHandler<GetWeatherForecastQuery, GetWeatherForecastResponse>,
                LoggingApplicationHandler<GetWeatherForecastQuery, GetWeatherForecastResponse>>();
    }
    
}