using System;

namespace RxBlazorApp.WeatherForecasts;

public class WeatherForecast
{
    public DateOnly Date { get; }

    public int TemperatureC { get; }

    public string? Summary { get; }

    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

    public static WeatherForecast Create(DateOnly date, int temperatureC, string? summary)
    {
        return new WeatherForecast(date, temperatureC, summary);
    }
    
    private WeatherForecast(DateOnly date, int temperatureC, string? summary)
    {
        Date = date;
        TemperatureC = temperatureC;
        Summary = summary;
    }
}