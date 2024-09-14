using ApplicationHandlers.DependencyInjection;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.DependencyInjection;
using TemplateProject.Application.Abstractions.Authentication;
using TemplateProject.Application.Abstractions.WeatherForecasts;
using TemplateProject.Blazor.Client.Authentication;
using TemplateProject.Blazor.Client.Handlers.Authentication;
using TemplateProject.Blazor.Client.Handlers.WeatherForecasts;

namespace TemplateProject.Blazor.Client.Handlers;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddHandlers(this IServiceCollection services)
    {
        return services
            .AddAuthentication()
            .AddWeatherForecasts();
    }
    
    private static IServiceCollection AddAuthentication(this IServiceCollection services)
    {
        return services
            .AddScoped<AuthenticationStateProvider, ClientAuthenticationStateProvider>()
            .AddQueryHandler<GetAuthenticatedUserQuery, GetAuthenticatedUserResponse, GetAuthenticatedUserHttpQueryHandler>();
    }

    private static IServiceCollection AddWeatherForecasts(this IServiceCollection services)
    {
        return services
            .AddQueryHandler<GetWeatherForecastQuery, GetWeatherForecastResponse, GetWeatherForecastHttpQueryHandler>();
    }
}