using System.Collections.Generic;
using TemplateProject.Application.Abstractions.WeatherForecasts.Models;

namespace TemplateProject.Application.Abstractions.WeatherForecasts;

public record GetWeatherForecastResponse(IReadOnlyCollection<WeatherForecastModel> WeatherForecasts);