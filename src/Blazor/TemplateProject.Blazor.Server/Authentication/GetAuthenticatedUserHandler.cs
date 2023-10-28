using System.Threading;
using System.Threading.Tasks;
using TemplateProject.Application.Abstractions.Authentication;
using TemplateProject.Application.Abstractions.Authentication.Models;

namespace TemplateProject.Blazor.Server.Authentication;

public class GetAuthenticatedUserHandler : IGetAuthenticatedUserHandler
{
    public Task<GetAuthenticatedUserResponse> Handle(GetAuthenticatedUserQuery request, CancellationToken cancellationToken)
    {
        var user = new AuthenticatedUserModel(
            UserLogin: "GoodUser",
            IsAuthenticated: true,
            Roles: new[] { "User" });

        var response = new GetAuthenticatedUserResponse(user);
        
        return Task.FromResult(response);
    }
}