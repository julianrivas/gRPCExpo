using Bitacoras.API.Consumers;
using Bitacoras.API.Services;

namespace Bitacoras.API.Configs;

public static class GrpcConfig
{
    public static void UseGrpc(this WebApplication app)
    {
        app.MapGrpcService<BitacoraConsumer>();
    }
}