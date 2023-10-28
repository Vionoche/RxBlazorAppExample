using System;

namespace ApplicationHandlers.Http.Exceptions;

public class ForbiddenHttpHandlerException<TExceptionData> : HttpHandlerException<TExceptionData>
{
    public ForbiddenHttpHandlerException()
    {
    }

    public ForbiddenHttpHandlerException(TExceptionData? exceptionData)
        : base(exceptionData)
    {
    }

    public ForbiddenHttpHandlerException(TExceptionData? exceptionData, Exception inner)
        : base(exceptionData, inner)
    {
    }
}