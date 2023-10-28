using System;
using Microsoft.Extensions.DependencyInjection;

namespace ApplicationHandlers.DependencyInjection;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddApplicationHandler<THandler, TRequest, TResponse, TImplementation>(
        this IServiceCollection services)
        where THandler : class, IApplicationHandler<TRequest, TResponse>
        where TImplementation : class, THandler
    {
        services
            .AddScoped<IApplicationHandler<TRequest, TResponse>, TImplementation>()
            .AddScoped<THandler>(
                s => (THandler)s.GetRequiredService<IApplicationHandler<TRequest, TResponse>>());

        return services;
    }

    public static IServiceCollection AddApplicationHandler<THandler, TRequest, TResponse>(
        this IServiceCollection services,
        Func<IServiceProvider, IApplicationHandler<TRequest, TResponse>> implementationFactory)
        where THandler : class, IApplicationHandler<TRequest, TResponse>
    {
        services
            .AddScoped(implementationFactory)
            .AddScoped<THandler>(
                s => (THandler)s.GetRequiredService<IApplicationHandler<TRequest, TResponse>>());

        return services;
    }

    public static IServiceCollection AddCommandHandler<THandler, TRequest, TResponse, TImplementation>(
        this IServiceCollection services)
        where THandler : class, IApplicationHandler<TRequest, TResponse>
        where TImplementation : class, THandler
    {
        services
            .AddScoped<IApplicationHandler<TRequest, TResponse>, TImplementation>()
            .AddScoped<ICommandHandler<TRequest, TResponse>>(
                s => (ICommandHandler<TRequest, TResponse>)s.GetRequiredService<IApplicationHandler<TRequest, TResponse>>())
            .AddScoped<THandler>(
                s => (THandler)s.GetRequiredService<IApplicationHandler<TRequest, TResponse>>());

        return services;
    }

    public static IServiceCollection AddCommandHandler<THandler, TRequest, TImplementation>(
        this IServiceCollection services)
        where THandler : class, IApplicationHandler<TRequest, Unit>
        where TImplementation : class, THandler
    {
        return services.AddCommandHandler<THandler, TRequest, Unit, TImplementation>();
    }

    public static IServiceCollection AddCommandHandler<THandler, TRequest, TResponse>(
        this IServiceCollection services,
        Func<IServiceProvider, IApplicationHandler<TRequest, TResponse>> implementationFactory)
        where THandler : class, IApplicationHandler<TRequest, TResponse>
    {
        services
            .AddScoped(implementationFactory)
            .AddScoped<ICommandHandler<TRequest, TResponse>>(
                s => (ICommandHandler<TRequest, TResponse>)s.GetRequiredService<IApplicationHandler<TRequest, TResponse>>())
            .AddScoped<THandler>(
                s => (THandler)s.GetRequiredService<IApplicationHandler<TRequest, TResponse>>());

        return services;
    }

    public static IServiceCollection AddQueryHandler<THandler, TRequest, TResponse, TImplementation>(
        this IServiceCollection services)
        where THandler : class, IApplicationHandler<TRequest, TResponse>
        where TImplementation : class, THandler
    {
        services
            .AddScoped<IApplicationHandler<TRequest, TResponse>, TImplementation>()
            .AddScoped<IQueryHandler<TRequest, TResponse>>(
                s => (IQueryHandler<TRequest, TResponse>)s.GetRequiredService<IApplicationHandler<TRequest, TResponse>>())
            .AddScoped<THandler>(
                s => (THandler)s.GetRequiredService<IApplicationHandler<TRequest, TResponse>>());

        return services;
    }

    public static IServiceCollection AddQueryHandler<THandler, TRequest, TResponse>(
        this IServiceCollection services,
        Func<IServiceProvider, IApplicationHandler<TRequest, TResponse>> implementationFactory)
        where THandler : class, IApplicationHandler<TRequest, TResponse>
    {
        services
            .AddScoped(implementationFactory)
            .AddScoped<IQueryHandler<TRequest, TResponse>>(
                s => (IQueryHandler<TRequest, TResponse>)s.GetRequiredService<IApplicationHandler<TRequest, TResponse>>())
            .AddScoped<THandler>(
                s => (THandler)s.GetRequiredService<IApplicationHandler<TRequest, TResponse>>());

        return services;
    }
}