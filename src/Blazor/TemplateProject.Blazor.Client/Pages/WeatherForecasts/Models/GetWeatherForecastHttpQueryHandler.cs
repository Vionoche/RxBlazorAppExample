using System.Net.Http;
using ApplicationHandlers.Http;
using TemplateProject.Application.Abstractions.WeatherForecasts;

namespace TemplateProject.Blazor.Client.Pages.WeatherForecasts.Models;

public class GetWeatherForecastHttpQueryHandler :
    DefaultHttpQueryHandler<GetWeatherForecastQuery, GetWeatherForecastResponse>,
    IGetWeatherForecastQueryHandler
{
    public GetWeatherForecastHttpQueryHandler(HttpClient httpClient) : base(httpClient, "api/weather-forecasts")
    {
    }
}