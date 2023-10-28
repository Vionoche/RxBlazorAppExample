using System;

namespace ApplicationHandlers.Http.Exceptions;

public class BadRequestHttpHandlerException<TExceptionData> : HttpHandlerException<TExceptionData>
{
    public BadRequestHttpHandlerException()
    {
    }

    public BadRequestHttpHandlerException(TExceptionData? exceptionData)
        : base(exceptionData)
    {
    }

    public BadRequestHttpHandlerException(TExceptionData? exceptionData, Exception inner)
        : base(exceptionData, inner)
    {
    }
}