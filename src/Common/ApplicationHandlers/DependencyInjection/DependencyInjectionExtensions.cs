using System;
using Microsoft.Extensions.DependencyInjection;

namespace ApplicationHandlers.DependencyInjection;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddHandler<THandler, TRequest, TResponse, TImplementation>(
        IServiceCollection services)
        where THandler : class, IApplicationHandler<TRequest, TResponse>
        where TImplementation : class, THandler
    {
        services
            .AddScoped<IApplicationHandler<TRequest, TResponse>, TImplementation>()
            .AddScoped<THandler>(s => (THandler)s.GetRequiredService<IApplicationHandler<TRequest, TResponse>>());
        
        return services;
    }
    
    public static IServiceCollection AddHandler<THandler, TRequest, TResponse>(
        IServiceCollection services,
        Func<IServiceProvider, IApplicationHandler<TRequest, TResponse>> implementationFactory)
        where THandler : class, IApplicationHandler<TRequest, TResponse>
    {
        services
            .AddScoped<IApplicationHandler<TRequest, TResponse>>(implementationFactory)
            .AddScoped<THandler>(s => (THandler)s.GetRequiredService<IApplicationHandler<TRequest, TResponse>>());
        
        return services;
    }
}