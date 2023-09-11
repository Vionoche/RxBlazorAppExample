using System;
using System.Threading;
using System.Threading.Tasks;
using ApplicationHandlers;
using Microsoft.Extensions.Logging;

namespace RxBlazorApp.Server.Logging;

public class LoggingApplicationHandler<TRequest, TResponse> : IApplicationHandler<TRequest, TResponse>
{
    public LoggingApplicationHandler(
        IApplicationHandler<TRequest, TResponse> decoratedHandler,
        ILogger<LoggingApplicationHandler<TRequest, TResponse>> logger)
    {
        _decoratedHandler = decoratedHandler;
        _logger = logger;
    }
    
    public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken)
    {
        const string handlerName = $"IApplicationHandler<{nameof(TRequest)}, {nameof(TResponse)}>";
        
        _logger.LogTrace($"Start processing handler {handlerName}...");

        try
        {
            var response = await _decoratedHandler.Handle(request, cancellationToken);
            return response;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.ToString());
            throw;
        }
        finally
        {
            _logger.LogTrace($"End processing handler {handlerName}.");
        }
    }

    private readonly IApplicationHandler<TRequest, TResponse> _decoratedHandler;
    private readonly ILogger<LoggingApplicationHandler<TRequest, TResponse>> _logger;
}