using System;

namespace ApplicationHandlers.Http.Exceptions;

public class UnauthorizedHttpHandlerException<TExceptionData> : HttpHandlerException<TExceptionData>
{
    public UnauthorizedHttpHandlerException()
    {
    }

    public UnauthorizedHttpHandlerException(TExceptionData? exceptionData)
        : base(exceptionData)
    {
    }

    public UnauthorizedHttpHandlerException(TExceptionData? exceptionData, Exception inner)
        : base(exceptionData, inner)
    {
    }
}