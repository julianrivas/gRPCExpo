using Common.HttpExceptions.Exceptions;
using Items.Application.Interfaces.Persistence;
using Items.Persistence.Context;
using Items.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Items.Persistence;

public static class DependencyInjection
{
    public static void AddPersistence(this IServiceCollection servicios, IConfiguration configuration)
    {
        var connectionString = configuration
            .GetConnectionString("DatabaseConnection");

        if (string.IsNullOrEmpty(connectionString))
            throw new ConflictException("The connectionString does not exist.");

        servicios.AddDbContext<ItemsContext>(options => options
            .UseSqlServer(connectionString));

        servicios.AddScoped<IItemDataRepository, ItemDataRepository>();
    }
}