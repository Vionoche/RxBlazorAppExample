using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using ApplicationHandlers;
using ApplicationHandlers.Http;
using TemplateProject.Application.Abstractions.Authentication;
using TemplateProject.Application.Abstractions.Exceptions;

namespace TemplateProject.Blazor.Client.Handlers.Authentication;

public class GetAuthenticatedUserHttpQueryHandler : IQueryHandler<GetAuthenticatedUserQuery, GetAuthenticatedUserResponse>
{
    public GetAuthenticatedUserHttpQueryHandler(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<GetAuthenticatedUserResponse> Handle(GetAuthenticatedUserQuery request, CancellationToken cancellationToken)
    {
        var response = await _httpClient.HandleHttpQueryMethod<GetAuthenticatedUserResponse, ExceptionData>(
            AuthenticationEndpoints.GetAuthenticatedUser, cancellationToken);
        return response;
    }
    
    private readonly HttpClient _httpClient;
}