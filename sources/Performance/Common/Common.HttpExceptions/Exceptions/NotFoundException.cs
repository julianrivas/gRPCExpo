using System.Net;
using Common.HttpExceptions.Base;

namespace Common.HttpExceptions.Exceptions;

public class NotFoundException(string message = "Resource not found") 
    : HttpException(message, HttpStatusCode.NotFound);