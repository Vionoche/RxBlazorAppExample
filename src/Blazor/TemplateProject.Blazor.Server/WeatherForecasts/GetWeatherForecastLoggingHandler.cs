using ApplicationHandlers;
using Microsoft.Extensions.Logging;
using TemplateProject.Application.Abstractions.WeatherForecasts;
using TemplateProject.Blazor.Server.Logging;

namespace TemplateProject.Blazor.Server.WeatherForecasts;

public class GetWeatherForecastLoggingHandler :
    LoggingApplicationHandler<GetWeatherForecastQuery, GetWeatherForecastResponse>,
    IGetWeatherForecastQueryHandler
{
    public GetWeatherForecastLoggingHandler(
        IApplicationHandler<GetWeatherForecastQuery, GetWeatherForecastResponse> decoratedHandler,
        ILoggerFactory loggerFactory)
        : base(decoratedHandler, loggerFactory)
    {
    }
}