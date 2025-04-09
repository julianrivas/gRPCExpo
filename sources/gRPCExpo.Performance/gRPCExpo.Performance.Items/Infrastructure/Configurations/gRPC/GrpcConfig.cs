using gRPCExpo.Performance.Items.Presentation.Consumers.rpcConsumers;

namespace gRPCExpo.Performance.Items.Infrastructure.Configurations.gRPC
{
    public static class GrpcConfig
    {
        public static void AddGrpcConfiguration(this IServiceCollection services)
        {
            services.AddGrpc();
        }

        public static void UseGrpcConfiguration(this WebApplication app)
        {
            app.MapGrpcService<ItemConsumer>();
        }
    }
}
