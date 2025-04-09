using gRPCExpo.Performance.Items.Infrastructure.Configurations.EFCore;
using gRPCExpo.Performance.Items.Infrastructure.Data.Context;
using gRPCExpo.Performance.Items.Infrastructure.Data.Interfaces;
using gRPCExpo.Performance.Items.Infrastructure.Data.Repository;

namespace gRPCExpo.Performance.Items.Infrastructure.Data.Resolver;

public static class DataResolver
{
    public static void AddDataServices(this IServiceCollection servicios, string? connectionString)
    {
        servicios.AddDbContext<ItemsContext>(EfCoreConfig.UseDatabase(connectionString));
        servicios.AddScoped<IItemDataRepository, ItemDataRepository>();
    }
}