using System;
using System.Net.Http;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor.Services;
using TemplateProject.Blazor.Client;
using TemplateProject.Blazor.Client.Authentication;
using TemplateProject.Blazor.Client.Pages.WeatherForecasts.Models;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services
    .AddAuthorizationCore()
    .AddAuthentication();

builder.Services
    .AddMudServices()
    .AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services
    .AddWeatherForecastComponents();

await builder.Build().RunAsync();
