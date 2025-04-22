using Items.API.Services;

namespace Items.API.Configs
{
    public static class GrpcConfig
    {
        public static void UseGrpc(this WebApplication app)
        {
            app.MapGrpcService<ItemConsumer>();
        }
    }
}
