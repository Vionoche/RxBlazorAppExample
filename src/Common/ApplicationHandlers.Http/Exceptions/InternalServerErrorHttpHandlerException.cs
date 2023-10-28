using System;

namespace ApplicationHandlers.Http.Exceptions;

public class InternalServerErrorHttpHandlerException<TExceptionData> : HttpHandlerException<TExceptionData>
{
    public InternalServerErrorHttpHandlerException()
    {
    }

    public InternalServerErrorHttpHandlerException(TExceptionData? exceptionData)
        : base(exceptionData)
    {
    }

    public InternalServerErrorHttpHandlerException(TExceptionData? exceptionData, Exception inner)
        : base(exceptionData, inner)
    {
    }
}