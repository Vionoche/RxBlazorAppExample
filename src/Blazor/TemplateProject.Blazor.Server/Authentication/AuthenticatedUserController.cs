using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TemplateProject.Application.Abstractions.Authentication;

namespace TemplateProject.Blazor.Server.Authentication;

[ApiController]
public class AuthenticatedUserController : ControllerBase
{
    public AuthenticatedUserController(IGetAuthenticatedUserHandler getAuthenticatedUserHandler)
    {
        _getAuthenticatedUserHandler = getAuthenticatedUserHandler;
    }

    [HttpGet(AuthenticationEndpoints.GetAuthenticatedUser)]
    public async Task<GetAuthenticatedUserResponse> GetAuthenticatedUser(CancellationToken cancellationToken)
    {
        var response = await _getAuthenticatedUserHandler.Handle(new GetAuthenticatedUserQuery(), cancellationToken);
        return response;
    }

    private readonly IGetAuthenticatedUserHandler _getAuthenticatedUserHandler;
}