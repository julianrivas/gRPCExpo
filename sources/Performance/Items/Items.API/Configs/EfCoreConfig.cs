using Common.HttpExceptions.Exceptions;
using Items.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Items.API.Configs;

public static class EfCoreConfig
{
    public static void UseEFCoreMigration(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var dbContext = scope.ServiceProvider
            .GetRequiredService<ItemsContext>();

        dbContext.Database.Migrate();
    }
}