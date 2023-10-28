using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TemplateProject.Blazor.Server.Authentication;
using TemplateProject.Blazor.Server.Exceptions;
using TemplateProject.Blazor.Server.WeatherForecasts;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddHttpContextAccessor()
    .AddControllersWithViews(options =>
    {
        options.Filters.Add<ApplicationHandlerExceptionAttribute>();
    })
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
    });

builder.Services
    .AddRazorPages();

builder.Services
    .AddAuthenticationHandlers()
    .AddWeatherForecastHandlers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseBlazorFrameworkFiles();
app.UseStaticFiles();
app.UseRouting();
app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
