using System.Net;

namespace Common.HttpExceptions.Base;

public abstract class HttpException(string message,
    HttpStatusCode statusCode) : Exception(message)
{
    public virtual HttpStatusCode StatusCode { get; } = statusCode;
}