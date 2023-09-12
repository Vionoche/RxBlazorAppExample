using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using ApplicationHandlers;
using Microsoft.Extensions.Logging;

namespace RxBlazorApp.Server.Logging;

public class LoggingApplicationHandler<TRequest, TResponse> : IApplicationHandler<TRequest, TResponse>
{
    public LoggingApplicationHandler(
        IApplicationHandler<TRequest, TResponse> decoratedHandler,
        ILoggerFactory loggerFactory)
    {
        _decoratedHandler = decoratedHandler;
        _logger = loggerFactory.CreateLogger(decoratedHandler.GetType()?.FullName ?? "LoggingApplicationHandler");
    }
    
    public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"Start processing handler");

        var stopWatch = Stopwatch.StartNew();
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
            stopWatch.Stop();
            _logger.LogInformation($"End processing handler in {stopWatch.Elapsed}");
        }
    }

    private readonly IApplicationHandler<TRequest, TResponse> _decoratedHandler;
    private readonly ILogger _logger;
}