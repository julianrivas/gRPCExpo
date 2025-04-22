using System.Net;
using Common.HttpExceptions.Base;

namespace Common.HttpExceptions.Exceptions;

public class ConflictException(string message = "Conflict") 
    : HttpException(message, HttpStatusCode.Conflict);