using System.Collections.Generic;
using System.Net.Http;
using ApplicationHandlers.Http.Exceptions;

namespace ApplicationHandlers.Http;

public class DefaultHttpQueryHandler<TRequest, TResponse> : HttpQueryHandlerBase<TRequest, TResponse>
{
    public DefaultHttpQueryHandler(HttpClient httpClient, string baseQueryUri) : base(httpClient, baseQueryUri)
    {
    }

    protected override IDictionary<string, string> GetQueryStringParameters(TRequest request)
    {
        var requestType = typeof(TRequest);

        if (!requestType.IsClass)
        {
            return new Dictionary<string, string>();    
        }

        var queryStringParameters = new Dictionary<string, string>();
        var properties = requestType.GetProperties();

        foreach (var property in properties)
        {
            var name = property.Name;
            var value = property.GetValue(request)?.ToString() ?? string.Empty;

            if (!queryStringParameters.TryAdd(name, value))
            {
                throw new HttpQueryHandlerException(
                    $"Query string parameter names must be unique in {requestType.FullName}.");
            }
        }

        return queryStringParameters;
    }
}