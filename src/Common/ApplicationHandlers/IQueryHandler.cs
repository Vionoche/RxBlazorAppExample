namespace ApplicationHandlers;

public interface IQueryHandler<in TRequest, TResponse> : IApplicationHandler<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
}