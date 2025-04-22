using Common.HttpExceptions.Base;
using System.Net;

namespace Common.HttpExceptions.Exceptions;

public class ForbiddenException(string message = "Forbidden") 
    : HttpException(message, HttpStatusCode.Forbidden);