using Items.Application.Interfaces.Persistence;
using Items.Persistence.Context;
using Items.Persistence.Context.Configs;
using Items.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Items.Persistence;

public static class DependencyInjection
{
    public static void AddPersistence(this IServiceCollection servicios, string? connectionString)
    {
        servicios.AddDbContext<ItemsContext>(EfCoreConfig.UseDatabase(connectionString));
        servicios.AddScoped<IItemDataRepository, ItemDataRepository>();
    }
}
