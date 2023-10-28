using ApplicationHandlers.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using TemplateProject.Application.Abstractions.Authentication;

namespace TemplateProject.Blazor.Server.Authentication;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddAuthenticationHandlers(this IServiceCollection services)
    {
        services
            .AddQueryHandler<IGetAuthenticatedUserHandler,
                GetAuthenticatedUserQuery, GetAuthenticatedUserResponse, GetAuthenticatedUserHandler>();
        
        return services;
    }
}