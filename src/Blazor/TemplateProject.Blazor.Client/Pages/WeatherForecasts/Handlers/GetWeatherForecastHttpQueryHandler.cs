using System.Net.Http;
using ApplicationHandlers.Http;
using TemplateProject.Application.Abstractions.Exceptions;
using TemplateProject.Application.Abstractions.WeatherForecasts;

namespace TemplateProject.Blazor.Client.Pages.WeatherForecasts.Handlers;

public class GetWeatherForecastHttpQueryHandler :
    DefaultHttpQueryHandler<GetWeatherForecastQuery, GetWeatherForecastResponse, ExceptionData>,
    IGetWeatherForecastQueryHandler
{
    public GetWeatherForecastHttpQueryHandler(HttpClient httpClient) : base(httpClient, WeatherForecastsEndpoints.GetWeatherForecast)
    {
    }
}