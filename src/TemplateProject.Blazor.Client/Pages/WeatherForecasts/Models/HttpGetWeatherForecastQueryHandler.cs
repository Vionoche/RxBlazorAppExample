using System.Net.Http;
using ApplicationHandlers.Http;
using RxBlazorApp.Shared.WeatherForecasts;

namespace RxBlazorApp.Client.Pages.WeatherForecasts.Models;

public class HttpGetWeatherForecastQueryHandler :
    DefaultHttpQueryHandler<GetWeatherForecastQuery, GetWeatherForecastResponse>,
    IGetWeatherForecastQueryHandler
{
    public HttpGetWeatherForecastQueryHandler(HttpClient httpClient) : base(httpClient, "api/weather-forecasts")
    {
    }
}