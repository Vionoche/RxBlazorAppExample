using System.Collections.Generic;
using ApplicationHandlers;
using TemplateProject.Application.Abstractions.WeatherForecasts.Models;

namespace TemplateProject.Application.Abstractions.WeatherForecasts;

public interface IGetWeatherForecastQueryHandler : IQueryHandler<GetWeatherForecastQuery, GetWeatherForecastResponse>
{
}

public record GetWeatherForecastQuery(
    int PageIndex,
    int PageSize);

public record GetWeatherForecastResponse(IReadOnlyCollection<WeatherForecastModel> WeatherForecasts);