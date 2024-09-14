using System.Threading;
using System.Threading.Tasks;
using ApplicationHandlers;
using Microsoft.AspNetCore.Mvc;
using TemplateProject.Application.Abstractions.WeatherForecasts;

namespace TemplateProject.Blazor.Server.WeatherForecasts;

[ApiController]
public class WeatherForecastsController : ControllerBase
{
    public WeatherForecastsController(
        IApplicationHandler<GetWeatherForecastQuery, GetWeatherForecastResponse> getWeatherForecastQueryHandler)
    {
        _getWeatherForecastQueryHandler = getWeatherForecastQueryHandler;
    }

    [HttpGet(WeatherForecastsEndpoints.GetWeatherForecast)]
    public async Task<GetWeatherForecastResponse> Get(
        [FromQuery]int pageIndex,
        [FromQuery]int pageSize,
        CancellationToken cancellationToken)
    {
        var response = await _getWeatherForecastQueryHandler.Handle(
            new GetWeatherForecastQuery(pageIndex, pageSize), cancellationToken);
        return response;
    }
    
    private readonly IApplicationHandler<GetWeatherForecastQuery, GetWeatherForecastResponse> _getWeatherForecastQueryHandler;
}