using System;
using Microsoft.Extensions.DependencyInjection;

namespace ApplicationHandlers.DependencyInjection;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddApplicationHandler<TRequest, TResponse, TImplementation>(
        this IServiceCollection services)
        where TImplementation : class, IApplicationHandler<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        return services
            .AddScoped<IApplicationHandler<TRequest, TResponse>, TImplementation>();
    }

    public static IServiceCollection AddApplicationHandler<TRequest, TResponse>(
        this IServiceCollection services,
        Func<IServiceProvider, IApplicationHandler<TRequest, TResponse>> implementationFactory)
        where TRequest : IRequest<TResponse>
    {
        return services
            .AddScoped(implementationFactory);
    }

    public static IServiceCollection AddCommandHandler<TRequest, TResponse, TImplementation>(
        this IServiceCollection services)
        where TImplementation : class, ICommandHandler<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        return services
            .AddScoped<IApplicationHandler<TRequest, TResponse>, TImplementation>()
            .AddScoped<ICommandHandler<TRequest, TResponse>>(
                s => (ICommandHandler<TRequest, TResponse>)s.GetRequiredService<IApplicationHandler<TRequest, TResponse>>());
    }

    public static IServiceCollection AddCommandHandler<TRequest, TResponse>(
        this IServiceCollection services,
        Func<IServiceProvider, IApplicationHandler<TRequest, TResponse>> implementationFactory)
        where TRequest : IRequest<TResponse>
    {
        return services
            .AddScoped(implementationFactory)
            .AddScoped<ICommandHandler<TRequest, TResponse>>(
                s => (ICommandHandler<TRequest, TResponse>)s.GetRequiredService<IApplicationHandler<TRequest, TResponse>>());
    }

    public static IServiceCollection AddQueryHandler<TRequest, TResponse, TImplementation>(
        this IServiceCollection services)
        where TImplementation : class, IApplicationHandler<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        return services
            .AddScoped<IApplicationHandler<TRequest, TResponse>, TImplementation>()
            .AddScoped<IQueryHandler<TRequest, TResponse>>(
                s => (IQueryHandler<TRequest, TResponse>)s.GetRequiredService<IApplicationHandler<TRequest, TResponse>>());
    }

    public static IServiceCollection AddQueryHandler<THandler, TRequest, TResponse>(
        this IServiceCollection services,
        Func<IServiceProvider, IApplicationHandler<TRequest, TResponse>> implementationFactory)
        where TRequest : IRequest<TResponse>
    {
        return services
            .AddScoped(implementationFactory)
            .AddScoped<IQueryHandler<TRequest, TResponse>>(
                s => (IQueryHandler<TRequest, TResponse>)s.GetRequiredService<IApplicationHandler<TRequest, TResponse>>());
    }
}