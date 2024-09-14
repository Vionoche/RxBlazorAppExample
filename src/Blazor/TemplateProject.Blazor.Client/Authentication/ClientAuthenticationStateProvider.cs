using System;
using System.Security.Claims;
using System.Threading.Tasks;
using ApplicationHandlers;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.Logging;
using TemplateProject.Application.Abstractions.Authentication;

namespace TemplateProject.Blazor.Client.Authentication;

public class ClientAuthenticationStateProvider : AuthenticationStateProvider
{
    public ClientAuthenticationStateProvider(
        IApplicationHandler<GetAuthenticatedUserQuery, GetAuthenticatedUserResponse> getAuthenticatedUserHandler,
        ILogger<ClientAuthenticationStateProvider> logger)
    {
        _getAuthenticatedUserHandler = getAuthenticatedUserHandler;
        _logger = logger;
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        return new AuthenticationState(await GetUser());
    }

    private async ValueTask<ClaimsPrincipal> GetUser(bool useCache = true)
    {
        var now = DateTimeOffset.Now;
        if (useCache && now < _userLastCheck + UserCacheRefreshInterval)
        {
            return _cachedUser;
        }

        _cachedUser = await FetchUser();
        _userLastCheck = now;

        return _cachedUser;
    }

    private async Task<ClaimsPrincipal> FetchUser()
    {
        try
        {
            var response = await _getAuthenticatedUserHandler.Handle(new GetAuthenticatedUserQuery());
            var user = response.User;

            if (!user.IsAuthenticated)
            {
                return new ClaimsPrincipal(new ClaimsIdentity());
            }

            var identity = new ClaimsIdentity(
                authenticationType: nameof(ClientAuthenticationStateProvider),
                nameType: NameClaimType,
                roleType: RoleClaimType);

            identity.AddClaim(new Claim(NameClaimType, user.UserLogin));

            foreach (var role in response.User.Roles)
            {
                identity.AddClaim(new Claim(RoleClaimType, role));
            }

            return new ClaimsPrincipal(identity);
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex, "Fetching user failed.");
        }

        return new ClaimsPrincipal(new ClaimsIdentity());
    }

    private static readonly TimeSpan UserCacheRefreshInterval = TimeSpan.FromSeconds(60);
    private DateTimeOffset _userLastCheck = DateTimeOffset.FromUnixTimeSeconds(0);
    private ClaimsPrincipal _cachedUser = new ClaimsPrincipal(new ClaimsIdentity());
    private const string NameClaimType = "name";
    private const string RoleClaimType = "role";

    private readonly IApplicationHandler<GetAuthenticatedUserQuery, GetAuthenticatedUserResponse> _getAuthenticatedUserHandler;
    private readonly ILogger<ClientAuthenticationStateProvider> _logger;
}