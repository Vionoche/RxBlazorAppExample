using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

using ApplicationHandlers.Http.Exceptions;
using ApplicationHandlers.Http.Helpers;


namespace ApplicationHandlers.Http;

public class HttpCommandHandler<TRequest, TResponse, TExceptionData> : HttpCommandHandlerBase<TRequest, TResponse, TExceptionData>
{
    public HttpCommandHandler(HttpClient httpClient, string commandUri)
    {
        _httpClient = httpClient;
        _commandUri = commandUri;
    }

    public override async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken)
    {
        var responseJson = await PerformPostRequest(_httpClient, _commandUri, request, cancellationToken);

        var response = !string.IsNullOrEmpty(responseJson)
            ? JsonHelper.Deserialize<TResponse>(responseJson)
            : default;

        if (response == null)
        {
            throw new HttpCommandHandlerException(
                $"HttpCommandHandler<{nameof(TRequest)}, {nameof(TResponse)}> gets null response from server.");
        }

        return response;
    }

    private readonly HttpClient _httpClient;
    private readonly string _commandUri;
}

public class HttpCommandHandler<TRequest, TExceptionData> :
    HttpCommandHandlerBase<TRequest, Unit, TExceptionData>,
    ICommandHandler<TRequest>
{
    public HttpCommandHandler(HttpClient httpClient, string commandUri)
    {
        _httpClient = httpClient;
        _commandUri = commandUri;
    }

    public override async Task<Unit> Handle(TRequest request, CancellationToken cancellationToken)
    {
        await PerformPostRequest(_httpClient, _commandUri, request, cancellationToken);
        return Unit.Value;
    }

    async Task ICommandHandler<TRequest>.Handle(TRequest request, CancellationToken cancellationToken)
    {
        await PerformPostRequest(_httpClient, _commandUri, request, cancellationToken);
    }

    private readonly HttpClient _httpClient;
    private readonly string _commandUri;
}