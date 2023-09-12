using System;

namespace RxBlazorApp.Shared.WeatherForecasts;

public record WeatherForecastModel(
    DateOnly Date,
    int TemperatureC,
    int TemperatureF,
    string? Summary);