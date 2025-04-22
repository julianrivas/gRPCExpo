using gRPCExpo.Performance.Items.Application.Resolver;
using gRPCExpo.Performance.Items.Infrastructure.Configurations.EFCore;
using gRPCExpo.Performance.Items.Infrastructure.Configurations.gRPC;
using gRPCExpo.Performance.Items.Infrastructure.Configurations.Masstransit;
using gRPCExpo.Performance.Items.Infrastructure.Configurations.Swagger;
using gRPCExpo.Performance.Items.Infrastructure.Data.Context;
using gRPCExpo.Performance.Items.Infrastructure.Data.Resolver;
using Mapster;
using Microsoft.AspNetCore.Server.Kestrel.Core;

namespace gRPCExpo.Performance.Items;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.WebHost.ConfigureKestrel(options =>
        {
            options.ListenAnyIP(8080, listenOptions =>
            {
                listenOptions.Protocols = HttpProtocols.Http1;
            });

            options.ListenAnyIP(8081, listenOptions =>
            {
                listenOptions.Protocols = HttpProtocols.Http2;
            });
        });


        var connectionString = builder.Configuration
            .GetConnectionString("DatabaseConnection");

        builder.Services.AddApplicationServices();
        builder.Services.AddDataServices(connectionString);
        
        builder.Services.AddMapster();
        builder.Services.AddControllers();
        builder.Services.AddSwaggerConfiguration();
        builder.Services.AddMasstransitConfiguration();
        builder.Services.AddGrpcConfiguration();

        var app = builder.Build();

        if (app.Environment.IsDevelopment()) 
            app.UseSwaggerDevelopmentConfiguration();

        app.UseGrpcConfiguration();
        app.Services.UseStartupMigration<ItemsContext>();
        app.UseAuthorization();
        app.MapControllers();
        app.Run();
    }
}