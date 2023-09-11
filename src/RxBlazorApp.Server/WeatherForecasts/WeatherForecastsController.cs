using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RxBlazorApp.Shared.WeatherForecasts;

namespace RxBlazorApp.Server.WeatherForecasts;

[ApiController]
[Route("[controller]")]
public class WeatherForecastsController : ControllerBase
{
    public WeatherForecastsController(IGetWeatherForecastHandler getWeatherForecastHandler)
    {
        _getWeatherForecastHandler = getWeatherForecastHandler;
    }

    [HttpGet]
    public async Task<GetWeatherForecastResponse> Get(CancellationToken cancellationToken)
    {
        var response = await _getWeatherForecastHandler.Handle(new GetWeatherForecastQuery(), cancellationToken);
        return response;
    }
    
    private readonly IGetWeatherForecastHandler _getWeatherForecastHandler;
}