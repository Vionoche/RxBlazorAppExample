using System.Collections.Generic;
using ApplicationHandlers;

namespace RxBlazorApp.Shared.WeatherForecasts;

public interface IGetWeatherForecastQueryHandler : IQueryHandler<GetWeatherForecastQuery, GetWeatherForecastResponse>
{
}

public record GetWeatherForecastQuery();

public record GetWeatherForecastResponse(IReadOnlyCollection<WeatherForecastModel> WeatherForecasts);