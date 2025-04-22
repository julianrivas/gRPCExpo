using System.Net;
using Common.HttpExceptions.Base;

namespace Common.HttpExceptions.Exceptions;

public class UnauthorizedException(string message = "Unauthorized")
    : HttpException(message, HttpStatusCode.Unauthorized);