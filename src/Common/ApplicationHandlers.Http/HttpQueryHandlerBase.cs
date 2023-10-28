using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using ApplicationHandlers.Http.Exceptions;
using ApplicationHandlers.Http.Helpers;


namespace ApplicationHandlers.Http;

public abstract class HttpQueryHandlerBase<TRequest, TResponse, TExceptionData> : IQueryHandler<TRequest, TResponse>
{
    protected HttpQueryHandlerBase(HttpClient httpClient, string baseQueryUri)
    {
        _httpClient = httpClient;
        _baseQueryUri = baseQueryUri;
    }

    public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken)
    {
        var parameters = GetQueryStringParameters(request);
        var queryUri = GetQueryUri(parameters);

        var httpResponse = await _httpClient.GetAsync(queryUri, cancellationToken);

        await HttpResponseMessageHelper<TExceptionData>.EnsureSuccessStatusCode(httpResponse);

        var responseJson = await httpResponse.Content.ReadAsStringAsync(cancellationToken);
        var response = JsonHelper.Deserialize<TResponse>(responseJson);

        if (response == null)
        {
            throw new HttpQueryHandlerException(
                $"HttpQueryHandler<{nameof(TRequest)}, {nameof(TResponse)}> gets null response from server.");
        }

        return response;
    }

    protected abstract IDictionary<string, string> GetQueryStringParameters(TRequest request);

    private string GetQueryUri(IDictionary<string, string> parameters)
    {
        if (parameters.Count == 0)
        {
            return _baseQueryUri;
        }

        var parameterStringPairs = new List<string>(parameters.Count);

        foreach (var (name, value) in parameters)
        {
            var escapedValue = Uri.EscapeDataString(value);
            parameterStringPairs.Add($"{name}={escapedValue}");
        }

        return _baseQueryUri +"?" + string.Join('&', parameterStringPairs);
    }

    protected readonly HttpClient _httpClient;
    protected readonly string _baseQueryUri;
}