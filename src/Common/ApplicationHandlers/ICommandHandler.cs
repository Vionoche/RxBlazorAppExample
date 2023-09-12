using System.Threading;
using System.Threading.Tasks;

namespace ApplicationHandlers;

public interface ICommandHandler<in TRequest, TResponse> : IApplicationHandler<TRequest, TResponse>
{
}

public interface ICommandHandler<in TRequest> : ICommandHandler<TRequest, Unit>
{
    async Task<Unit> IApplicationHandler<TRequest, Unit>.Handle(TRequest request, CancellationToken cancellationToken)
    {
        await Handle(request, cancellationToken);
        return Unit.Value;
    }

    new Task Handle(TRequest request, CancellationToken cancellationToken);
}