using ApplicationHandlers;
using Microsoft.Extensions.Logging;
using RxBlazorApp.Server.Logging;
using RxBlazorApp.Shared.WeatherForecasts;

namespace RxBlazorApp.Server.WeatherForecasts;

public class LoggingGetWeatherForecastQueryHandler :
    LoggingApplicationHandler<GetWeatherForecastQuery, GetWeatherForecastResponse>,
    IGetWeatherForecastQueryHandler
{
    public LoggingGetWeatherForecastQueryHandler(
        IApplicationHandler<GetWeatherForecastQuery, GetWeatherForecastResponse> decoratedHandler,
        ILoggerFactory loggerFactory)
        : base(decoratedHandler, loggerFactory)
    {
    }
}