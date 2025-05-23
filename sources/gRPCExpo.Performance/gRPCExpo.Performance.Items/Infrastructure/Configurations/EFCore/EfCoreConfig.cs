﻿using gRPCExpo.Performance.Exceptions.Http;
using Microsoft.EntityFrameworkCore;

namespace gRPCExpo.Performance.Items.Infrastructure.Configurations.EFCore;

public static class EfCoreConfig
{
    public static Action<DbContextOptionsBuilder> UseDatabase(string? connectionString)
    {
        if (string.IsNullOrEmpty(connectionString))
            throw new InternalServerErrorException(
                "The connectionString does not exist.");

        return options => options
            .UseSqlServer(connectionString);
    }

    public static void UseStartupMigration<T>(this IServiceProvider service) where T : DbContext
    {
        using var scope = service.CreateScope();
        var dbContext = scope.ServiceProvider
            .GetRequiredService<T>();

        dbContext.Database.Migrate();
    }
}