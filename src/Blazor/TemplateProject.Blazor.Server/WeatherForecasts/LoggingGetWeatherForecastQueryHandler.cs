using ApplicationHandlers;
using Microsoft.Extensions.Logging;
using TemplateProject.Application.Abstractions.WeatherForecasts;
using TemplateProject.Blazor.Server.Logging;

namespace TemplateProject.Blazor.Server.WeatherForecasts;

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