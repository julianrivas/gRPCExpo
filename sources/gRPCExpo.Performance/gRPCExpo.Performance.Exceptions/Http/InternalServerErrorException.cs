using System.Net;

namespace gRPCExpo.Performance.Exceptions.Http
{
    public class InternalServerErrorException(string message) : CustomException(HttpStatusCode.Conflict, message);
}