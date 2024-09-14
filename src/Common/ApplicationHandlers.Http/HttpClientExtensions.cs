using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ApplicationHandlers.Http.Exceptions;
using ApplicationHandlers.Http.Helpers;

namespace ApplicationHandlers.Http;

public static class HttpClientExtensions
{
    public static async Task<TResponse> HandleHttpQueryMethod<TResponse, TExceptionData>(
        this HttpClient httpClient, string route, CancellationToken cancellationToken)
    {
        var responseMessage = await httpClient.GetAsync(route, cancellationToken);
        
        await HttpResponseMessageHelper<TExceptionData>.EnsureSuccessStatusCode(responseMessage);
        
        var responseJson = await responseMessage.Content.ReadAsStringAsync(cancellationToken);
        var response = JsonHelper.Deserialize<TResponse>(responseJson);

        if (response == null)
        {
            throw new HttpClientQueryException($"Http request GET {route} gets null response from server.");
        }
        
        return response;
    }
    
    public static async Task HandleHttpCommandMethod<TExceptionData>(
        this HttpClient httpClient, HttpMethod method, string route, CancellationToken cancellationToken)
    {
        using var requestMessage = new HttpRequestMessage(method, route);

        var responseMessage = await httpClient.SendAsync(requestMessage, cancellationToken);

        await HttpResponseMessageHelper<TExceptionData>.EnsureSuccessStatusCode(responseMessage);
    }

    public static async Task HandleHttpCommandMethod<TCommand, TExceptionData>(
        this HttpClient httpClient, HttpMethod method, string route, TCommand command, CancellationToken cancellationToken)
        where TCommand : class
    {
        using var requestMessage = new HttpRequestMessage(method, route);

        if (method == HttpMethod.Post || method == HttpMethod.Put || method == HttpMethod.Patch)
        {
            requestMessage.Content = CreateJsonContent(command);
        }

        var responseMessage = await httpClient.SendAsync(requestMessage, cancellationToken);

        await HttpResponseMessageHelper<TExceptionData>.EnsureSuccessStatusCode(responseMessage);
    }

    public static async Task<TResponse> HandleHttpCommandMethod<TCommand, TResponse, TExceptionData>(
        this HttpClient httpClient, HttpMethod method, string route, TCommand command, CancellationToken cancellationToken)
        where TCommand : class
    {
        using var requestMessage = new HttpRequestMessage(method, route);

        if (method == HttpMethod.Post || method == HttpMethod.Put || method == HttpMethod.Patch)
        {
            requestMessage.Content = CreateJsonContent(command);
        }

        var responseMessage = await httpClient.SendAsync(requestMessage, cancellationToken);

        await HttpResponseMessageHelper<TExceptionData>.EnsureSuccessStatusCode(responseMessage);

        var responseJson = await responseMessage.Content.ReadAsStringAsync(cancellationToken);
        var response = JsonHelper.Deserialize<TResponse>(responseJson);

        if (response == null)
        {
            throw new HttpClientCommandException($"Http request POST {route} gets null response from server.");
        }

        return response;
    }

    private static StringContent CreateJsonContent<TCommand>(TCommand command)
    {
        return new StringContent(
            content: JsonHelper.Serialize(command),
            encoding: Encoding.UTF8,
            mediaType: "application/json");
    }
}