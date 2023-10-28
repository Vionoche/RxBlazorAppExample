using System.Net.Http;
using ApplicationHandlers.Http;
using TemplateProject.Application.Abstractions.Authentication;
using TemplateProject.Application.Abstractions.Exceptions;

namespace TemplateProject.Blazor.Client.Authentication.Handlers;

public class GetAuthenticatedUserHttpQueryHandler :
    DefaultHttpQueryHandler<GetAuthenticatedUserQuery, GetAuthenticatedUserResponse, ExceptionData>,
    IGetAuthenticatedUserHandler
{
    public GetAuthenticatedUserHttpQueryHandler(HttpClient httpClient) : base(httpClient, AuthenticationEndpoints.GetAuthenticatedUser)
    {
    }
}