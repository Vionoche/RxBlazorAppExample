using System;

namespace ApplicationHandlers.Http.Exceptions;

public class NotFoundHttpHandlerException<TExceptionData> : HttpHandlerException<TExceptionData>
{
    public NotFoundHttpHandlerException()
    {
    }

    public NotFoundHttpHandlerException(TExceptionData? exceptionData)
        : base(exceptionData)
    {
    }

    public NotFoundHttpHandlerException(TExceptionData? exceptionData, Exception inner)
        : base(exceptionData, inner)
    {
    }
}