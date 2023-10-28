using System;

namespace TemplateProject.Exceptions;

public class TemplateProjectException : Exception
{
    public TemplateProjectException()
    {
    }

    public TemplateProjectException(string message) : base(message)
    {
    }

    public TemplateProjectException(string message, Exception inner) : base(message, inner)
    {
    }
}