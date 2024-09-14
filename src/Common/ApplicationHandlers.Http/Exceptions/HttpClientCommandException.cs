using System;

namespace ApplicationHandlers.Http.Exceptions;

public class HttpClientCommandException : Exception
{
    public HttpClientCommandException() { }
    public HttpClientCommandException(string message) : base(message) { }
    public HttpClientCommandException(string message, Exception inner) : base(message, inner) { }
}