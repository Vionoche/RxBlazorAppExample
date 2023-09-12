using System;

namespace ApplicationHandlers.Http.Exceptions;

public class HttpQueryHandlerException : Exception
{
    public HttpQueryHandlerException() { }
    public HttpQueryHandlerException(string message) : base(message) { }
    public HttpQueryHandlerException(string message, Exception inner) : base(message, inner) { }
}