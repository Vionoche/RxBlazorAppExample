using System;

namespace TemplateProject.Application.Abstractions.WeatherForecasts;

public record WeatherForecastModel(
    DateOnly Date,
    int TemperatureC,
    int TemperatureF,
    string? Summary);