using System.Threading;
using System.Threading.Tasks;

namespace ApplicationHandlers;

public interface IQueryHandler<in TRequest, TResponse> : IApplicationHandler<TRequest, TResponse>
{
}

public interface IQueryHandler<TResponse> : IQueryHandler<Unit, TResponse>
{
    Task<TResponse> Handle(CancellationToken cancellationToken)
    {
        return Handle(Unit.Value, cancellationToken);
    }
}