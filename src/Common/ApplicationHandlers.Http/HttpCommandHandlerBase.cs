using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using ApplicationHandlers.Http.Helpers;


namespace ApplicationHandlers.Http;

public abstract class HttpCommandHandlerBase<TRequest, TResponse, TExceptionData> : ICommandHandler<TRequest, TResponse>
{
    public abstract Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);

    protected static async Task<string?> PerformPostRequest(
        HttpClient httpClient, string commandUri, TRequest request, CancellationToken cancellationToken)
    {
        var requestJson = JsonHelper.Serialize(request);

        var content = new StringContent(
            content: requestJson,
            encoding: Encoding.UTF8,
            mediaType: "application/json");

        var httpResponse = await httpClient.PostAsync(commandUri, content, cancellationToken);

        await HttpResponseMessageHelper<TExceptionData>.EnsureSuccessStatusCode(httpResponse);

        var responseJson = await httpResponse.Content.ReadAsStringAsync(cancellationToken);

        return responseJson;
    }
}