using System.Net;

namespace gRPCExpo.Performance.Exceptions.Http
{
    public class ConflictExcepcion(string message) : CustomException(HttpStatusCode.Conflict, message);
}