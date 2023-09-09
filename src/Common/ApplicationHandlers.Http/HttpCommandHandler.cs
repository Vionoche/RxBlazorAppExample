using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using ApplicationHandlers.Http.Exceptions;

namespace ApplicationHandlers.Http;

public class HttpCommandHandler<TRequest, TResponse> : ICommandHandler<TRequest, TResponse>
{
    public HttpCommandHandler(HttpClient httpClient, Uri commandUri)
    {
        _httpClient = httpClient;
        _commandUri = commandUri;
    }
    
    public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken)
    {
        var requestJson = JsonSerializer.Serialize(request);
        var content = new StringContent(requestJson);

        var httpResponse = await _httpClient.PostAsync(_commandUri, content, cancellationToken);
        httpResponse.EnsureSuccessStatusCode();

        var responseJson = await httpResponse.Content.ReadAsStringAsync(cancellationToken);
        var response = JsonSerializer.Deserialize<TResponse>(responseJson);

        if (response == null)
        {
            throw new HttpCommandHandlerException(
                $"HttpCommandHandler<{nameof(TRequest)}, {nameof(TResponse)}> gets null response from server.");
        }

        return response;
    }
    
    private readonly HttpClient _httpClient;
    private readonly Uri _commandUri;
}

public class HttpCommandHandler<TRequest> : ICommandHandler<TRequest>
{
    public HttpCommandHandler(HttpClient httpClient, Uri commandUri)
    {
        _httpClient = httpClient;
        _commandUri = commandUri;
    }
    
    public async Task Handle(TRequest request, CancellationToken cancellationToken)
    {
        var requestJson = JsonSerializer.Serialize(request);
        var content = new StringContent(requestJson);

        var httpResponse = await _httpClient.PostAsync(_commandUri, content, cancellationToken);
        httpResponse.EnsureSuccessStatusCode();

        await httpResponse.Content.ReadAsStringAsync(cancellationToken);
    }
    
    private readonly HttpClient _httpClient;
    private readonly Uri _commandUri;
}