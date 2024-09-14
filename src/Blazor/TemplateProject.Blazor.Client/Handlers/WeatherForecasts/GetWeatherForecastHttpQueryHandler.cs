using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using ApplicationHandlers;
using ApplicationHandlers.Http;
using TemplateProject.Application.Abstractions.Exceptions;
using TemplateProject.Application.Abstractions.WeatherForecasts;

namespace TemplateProject.Blazor.Client.Handlers.WeatherForecasts;

public class GetWeatherForecastHttpQueryHandler : IQueryHandler<GetWeatherForecastQuery, GetWeatherForecastResponse>
{
    public GetWeatherForecastHttpQueryHandler(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<GetWeatherForecastResponse> Handle(GetWeatherForecastQuery request, CancellationToken cancellationToken)
    {
        var route = $"{WeatherForecastsEndpoints.GetWeatherForecast}?pageIndex={request.PageIndex}&pageSize={request.PageSize}";
        
        var response = await _httpClient.HandleHttpQueryMethod<GetWeatherForecastResponse, ExceptionData>(route, cancellationToken);
        
        return response;
    }

    private readonly HttpClient _httpClient;
}