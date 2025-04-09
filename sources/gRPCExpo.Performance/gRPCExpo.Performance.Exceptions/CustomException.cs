using System.Net;

namespace gRPCExpo.Performance.Exceptions;

public class CustomException : Exception
{
    public HttpStatusCode StatusCode;

    public CustomException(string message) : base(message) { }

    public object? Details { get; }

    public CustomException(HttpStatusCode statusCode, string message) : base(message)
    {
        StatusCode = statusCode;
    }

    public CustomException(HttpStatusCode statusCode, string message, object details) : base(message)
    {
        StatusCode = statusCode;
        Details = details;
    }
}