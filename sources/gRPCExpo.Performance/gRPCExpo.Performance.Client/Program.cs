using gRPCExpo.Performance.Client.Configurations.Masstransit;

namespace gRPCExpo.Performance.Client;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddMasstransitConfiguration();

        builder.Services.AddControllers();

        var app = builder.Build();

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}