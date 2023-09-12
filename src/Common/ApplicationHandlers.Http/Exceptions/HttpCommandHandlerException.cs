using System;

namespace ApplicationHandlers.Http.Exceptions;

public class HttpCommandHandlerException : Exception
{
    public HttpCommandHandlerException() { }
    public HttpCommandHandlerException(string message) : base(message) { }
    public HttpCommandHandlerException(string message, Exception inner) : base(message, inner) { }
}