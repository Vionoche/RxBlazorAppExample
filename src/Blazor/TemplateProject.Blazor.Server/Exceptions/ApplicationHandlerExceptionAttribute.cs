using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using TemplateProject.Application.Abstractions.Exceptions;
using TemplateProject.Exceptions;

namespace TemplateProject.Blazor.Server.Exceptions;

public class ApplicationHandlerExceptionAttribute : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        context.Result = context.Exception switch
        {
            TemplateProjectException ex => CreateContentResult(HttpStatusCode.BadRequest, ex.Message),
            _ => CreateContentResult(HttpStatusCode.InternalServerError, "Internal server error")
        };
    }

    private static ContentResult CreateContentResult(
        HttpStatusCode statusCode,
        string message)
    {
        var response = new ExceptionData(message);
        var jsonResponse = JsonSerializer.Serialize(response);

        return new ContentResult
        {
            Content = jsonResponse,
            ContentType = "application/json",
            StatusCode = (int)statusCode
        };
    }
}