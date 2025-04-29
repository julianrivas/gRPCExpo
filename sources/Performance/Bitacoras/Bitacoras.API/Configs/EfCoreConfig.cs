using Bitacoras.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Bitacoras.API.Configs;

public static class EfCoreConfig
{
    public static void UseEFCoreMigration(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var dbContext = scope.ServiceProvider
            .GetRequiredService<BitacorasContext>();

        dbContext.Database.Migrate();
    }
}