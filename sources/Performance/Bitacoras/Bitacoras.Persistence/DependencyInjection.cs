using Bitacoras.Application.Interfaces.Persistence;
using Bitacoras.Persistence.Context;
using Bitacoras.Persistence.Repositories;
using Common.HttpExceptions.Exceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Bitacoras.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection servicios, IConfiguration configuration)
    {
        var connectionString = configuration
            .GetConnectionString("DatabaseConnection");

        if (string.IsNullOrEmpty(connectionString))
            throw new ConflictException("The connectionString does not exist.");

        servicios.AddDbContext<BitacorasContext>(options => options
            .UseSqlServer(connectionString, dbOptions =>
                dbOptions.MigrationsHistoryTable("Bitacoras_MigrationHistory", "grpcexpo")));

        servicios.AddScoped<IBitacoraDataRepository, BitacoraDataRepository>();

        return servicios;
    }
}