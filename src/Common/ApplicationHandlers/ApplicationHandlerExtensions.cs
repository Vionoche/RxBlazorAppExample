using System.Threading;
using System.Threading.Tasks;

namespace ApplicationHandlers;

public static class ApplicationHandlerExtensions
{
    public static Task<TResponse> Handle<TRequest, TResponse>(
        this IApplicationHandler<TRequest, TResponse> handler,
        TRequest request)
    {
        return handler.Handle(request, CancellationToken.None);
    }
}