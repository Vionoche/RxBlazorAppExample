using System.Threading;
using System.Threading.Tasks;

namespace ApplicationHandlers;

public interface IApplicationHandler<in TRequest, TResponse>
{
    Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);
}