using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TemplateProject.Application.Abstractions.WeatherForecasts;

namespace TemplateProject.Blazor.Server.WeatherForecasts;

[ApiController]
[Route("api/weather-forecasts")]
public class WeatherForecastsController : ControllerBase
{
    public WeatherForecastsController(IGetWeatherForecastQueryHandler getWeatherForecastQueryHandler)
    {
        _getWeatherForecastQueryHandler = getWeatherForecastQueryHandler;
    }

    [HttpGet]
    public async Task<GetWeatherForecastResponse> Get(CancellationToken cancellationToken)
    {
        var response = await _getWeatherForecastQueryHandler.Handle(new GetWeatherForecastQuery(), cancellationToken);
        return response;
    }
    
    private readonly IGetWeatherForecastQueryHandler _getWeatherForecastQueryHandler;
}