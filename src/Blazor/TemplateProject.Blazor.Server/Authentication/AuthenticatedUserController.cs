using System.Threading;
using System.Threading.Tasks;
using ApplicationHandlers;
using Microsoft.AspNetCore.Mvc;
using TemplateProject.Application.Abstractions.Authentication;

namespace TemplateProject.Blazor.Server.Authentication;

[ApiController]
public class AuthenticatedUserController : ControllerBase
{
    public AuthenticatedUserController(
        IApplicationHandler<GetAuthenticatedUserQuery, GetAuthenticatedUserResponse> getAuthenticatedUserHandler)
    {
        _getAuthenticatedUserHandler = getAuthenticatedUserHandler;
    }

    [HttpGet(AuthenticationEndpoints.GetAuthenticatedUser)]
    public async Task<GetAuthenticatedUserResponse> GetAuthenticatedUser(CancellationToken cancellationToken)
    {
        var response = await _getAuthenticatedUserHandler.Handle(new GetAuthenticatedUserQuery(), cancellationToken);
        return response;
    }

    private readonly IApplicationHandler<GetAuthenticatedUserQuery, GetAuthenticatedUserResponse> _getAuthenticatedUserHandler;
}