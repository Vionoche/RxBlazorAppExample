using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using ApplicationHandlers.Http.Exceptions;

namespace ApplicationHandlers.Http.Helpers;

public static class HttpResponseMessageHelper<TExceptionData>
{
    public static async Task EnsureSuccessStatusCode(HttpResponseMessage responseMessage)
    {
        if (responseMessage.IsSuccessStatusCode)
        {
            return;
        }

        var responseJson = await responseMessage.Content.ReadAsStringAsync();

        var exceptionData = TryParseExceptionData(responseJson);

        if (ExceptionActions.TryGetValue(responseMessage.StatusCode, out var exceptionAction))
        {
            exceptionAction(exceptionData);
        }

        throw new HttpHandlerException<TExceptionData>(exceptionData);
    }

    private static TExceptionData? TryParseExceptionData(string? responseJson)
    {
        if (string.IsNullOrEmpty(responseJson))
        {
            return default;
        }

        try
        {
            return JsonHelper.Deserialize<TExceptionData>(responseJson);
        }
        catch
        {
            return default;
        }
    }

    private static readonly Dictionary<HttpStatusCode, Action<TExceptionData?>> ExceptionActions = new()
    {
        { HttpStatusCode.BadRequest, exceptionData => throw new BadRequestHttpHandlerException<TExceptionData>(exceptionData) },
        { HttpStatusCode.Forbidden, exceptionData => throw new ForbiddenHttpHandlerException<TExceptionData>(exceptionData) },
        { HttpStatusCode.InternalServerError, exceptionData => throw new InternalServerErrorHttpHandlerException<TExceptionData>(exceptionData) },
        { HttpStatusCode.NotFound, exceptionData => throw new NotFoundHttpHandlerException<TExceptionData>(exceptionData) },
        { HttpStatusCode.Unauthorized, exceptionData => throw new UnauthorizedHttpHandlerException<TExceptionData>(exceptionData) }
    };
}