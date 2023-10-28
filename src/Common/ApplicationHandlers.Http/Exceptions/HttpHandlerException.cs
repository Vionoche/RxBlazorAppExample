using System;

namespace ApplicationHandlers.Http.Exceptions;

public class HttpHandlerException<TExceptionData> : Exception
{
    public TExceptionData? ExceptionData => _exceptionData;

    public HttpHandlerException()
    {
    }

    public HttpHandlerException(TExceptionData? exceptionData)
        : base(exceptionData?.ToString())
    {
        _exceptionData = exceptionData;
    }

    public HttpHandlerException(TExceptionData? exceptionData, Exception inner)
        : base(exceptionData?.ToString(), inner)
    {
        _exceptionData = exceptionData;
    }

    protected readonly TExceptionData? _exceptionData;
}