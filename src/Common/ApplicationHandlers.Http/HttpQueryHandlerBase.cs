using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using ApplicationHandlers.Http.Exceptions;

namespace ApplicationHandlers.Http;

public abstract class HttpQueryHandlerBase<TRequest, TResponse> : IQueryHandler<TRequest, TResponse>
{
    protected HttpQueryHandlerBase(HttpClient httpClient, Uri baseQueryUri)
    {
        HttpClient = httpClient;
        BaseQueryUri = baseQueryUri;
    }
    
    public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken)
    {
        var parameters = GetQueryStringParameters(request);
        var queryUri = GetQueryUri(parameters);
        
        var httpResponse = await HttpClient.GetAsync(queryUri, cancellationToken);
        httpResponse.EnsureSuccessStatusCode();
        
        var responseJson = await httpResponse.Content.ReadAsStringAsync(cancellationToken);
        var response = JsonSerializer.Deserialize<TResponse>(responseJson);

        if (response == null)
        {
            throw new HttpQueryHandlerException(
                $"HttpQueryHandler<{nameof(TRequest)}, {nameof(TResponse)}> gets null response from server.");
        }

        return response;
    }

    protected abstract IDictionary<string, string> GetQueryStringParameters(TRequest request);

    private Uri GetQueryUri(IDictionary<string, string> parameters)
    {
        if (parameters.Count == 0)
        {
            return BaseQueryUri;
        }

        var parameterStringPairs = new List<string>(parameters.Count);
        
        foreach (var (name, value) in parameters)
        {
            var escapedValue = Uri.EscapeDataString(value);
            parameterStringPairs.Add($"{name}={escapedValue}");
        }

        var queryString = "?" + string.Join('&', parameterStringPairs);

        return new Uri(BaseQueryUri, queryString);
    }
    
    protected readonly HttpClient HttpClient;
    protected readonly Uri BaseQueryUri;
}