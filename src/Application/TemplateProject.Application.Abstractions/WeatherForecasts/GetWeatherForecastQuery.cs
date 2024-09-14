using ApplicationHandlers;

namespace TemplateProject.Application.Abstractions.WeatherForecasts;

public record GetWeatherForecastQuery(
    int PageIndex,
    int PageSize)
    : IRequest<GetWeatherForecastResponse>;