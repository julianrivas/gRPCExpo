using System.Net;
using Common.HttpExceptions.Base;

namespace Common.HttpExceptions.Exceptions;

public class BadRequestException(string message = "Bad request") 
    : HttpException(message, HttpStatusCode.BadRequest);