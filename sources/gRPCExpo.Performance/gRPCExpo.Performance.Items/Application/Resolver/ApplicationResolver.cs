using gRPCExpo.Performance.Items.Application.Interfaces;
using gRPCExpo.Performance.Items.Application.Queries;

namespace gRPCExpo.Performance.Items.Application.Resolver;

public static class ApplicationResolver
{
    public static void AddApplicationServices(this IServiceCollection servicios)
    {
        servicios.AddScoped<IItemQuery, ItemQuery>();
    }
}