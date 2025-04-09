using System.Net;

namespace gRPCExpo.Performance.Exceptions.Http
{
    public class NotFoundException(string message) : CustomException(HttpStatusCode.NotFound, message);
}