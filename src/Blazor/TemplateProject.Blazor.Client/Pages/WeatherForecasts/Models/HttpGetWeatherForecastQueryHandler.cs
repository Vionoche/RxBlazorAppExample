using System.Net.Http;
using ApplicationHandlers.Http;
using TemplateProject.Application.Abstractions.WeatherForecasts;

namespace TemplateProject.Blazor.Client.Pages.WeatherForecasts.Models;

public class HttpGetWeatherForecastQueryHandler :
    DefaultHttpQueryHandler<GetWeatherForecastQuery, GetWeatherForecastResponse>,
    IGetWeatherForecastQueryHandler
{
    public HttpGetWeatherForecastQueryHandler(HttpClient httpClient) : base(httpClient, "api/weather-forecasts")
    {
    }
}