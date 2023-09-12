using System.Collections.Generic;
using System.Net.Http;

namespace ApplicationHandlers.Http;

public class DefaultHttpQueryHandler<TRequest, TResponse> : HttpQueryHandlerBase<TRequest, TResponse>
{
    public DefaultHttpQueryHandler(HttpClient httpClient, string baseQueryUri) : base(httpClient, baseQueryUri)
    {
    }

    protected override IDictionary<string, string> GetQueryStringParameters(TRequest request)
    {
        return new Dictionary<string, string>();
    }
}