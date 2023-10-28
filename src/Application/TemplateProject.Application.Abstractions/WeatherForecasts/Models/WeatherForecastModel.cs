using System;

namespace TemplateProject.Application.Abstractions.WeatherForecasts.Models;

public record WeatherForecastModel(
    DateOnly Date,
    int TemperatureC,
    int TemperatureF,
    string? Summary);