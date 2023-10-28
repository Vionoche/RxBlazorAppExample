using ApplicationHandlers.DependencyInjection;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.DependencyInjection;
using TemplateProject.Application.Abstractions.Authentication;
using TemplateProject.Blazor.Client.Authentication.Handlers;

namespace TemplateProject.Blazor.Client.Authentication;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddAuthentication(this IServiceCollection services)
    {
        services
            .AddScoped<AuthenticationStateProvider, ClientAuthenticationStateProvider>()
            .AddQueryHandler<IGetAuthenticatedUserHandler,
                GetAuthenticatedUserQuery, GetAuthenticatedUserResponse, GetAuthenticatedUserHttpQueryHandler>();

        return services;
    }
}