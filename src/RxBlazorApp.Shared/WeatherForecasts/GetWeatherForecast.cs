using System.Collections.Generic;
using ApplicationHandlers;

namespace RxBlazorApp.Shared.WeatherForecasts;

public interface IGetWeatherForecastHandler : IQueryHandler<GetWeatherForecastQuery, GetWeatherForecastResponse>
{
}

public record GetWeatherForecastQuery();

public record GetWeatherForecastResponse(IReadOnlyCollection<WeatherForecastModel> WeatherForecasts);