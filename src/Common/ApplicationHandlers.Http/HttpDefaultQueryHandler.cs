using System;
using System.Collections.Generic;
using System.Net.Http;

namespace ApplicationHandlers.Http;

public class HttpDefaultQueryHandler<TRequest, TResponse> : HttpQueryHandlerBase<TRequest, TResponse>
{
    public HttpDefaultQueryHandler(HttpClient httpClient, Uri baseQueryUri) : base(httpClient, baseQueryUri)
    {
    }

    protected override IDictionary<string, string> GetQueryStringParameters(TRequest request)
    {
        return new Dictionary<string, string>();
    }
}