using Items.Application;
using Items.Grpc.Services;
using Items.Persistence;
using Mapster;

namespace Items.Grpc;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication
            .CreateBuilder(args);

        builder.Services
            .AddApplication()
            .AddPersistence(builder.Configuration);

        // Add services to the container.
        builder.Services.AddGrpc();
        builder.Services.AddMapster();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        app.MapGrpcService<ItemService>();
        app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client.");

        app.Run();
    }
}