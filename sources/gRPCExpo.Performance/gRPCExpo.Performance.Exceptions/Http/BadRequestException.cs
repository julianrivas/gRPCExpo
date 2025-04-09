using System.Net;

namespace gRPCExpo.Performance.Exceptions.Http
{
    public class BadRequestException(string message) : CustomException(HttpStatusCode.BadRequest, message);
}