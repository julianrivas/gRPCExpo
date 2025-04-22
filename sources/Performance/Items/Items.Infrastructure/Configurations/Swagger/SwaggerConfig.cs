namespace gRPCExpo.Performance.Items.Infrastructure.Configurations.Swagger;

public static class SwaggerConfig
{
    public static void AddSwaggerConfiguration(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
    }

    public static void UseSwaggerDevelopmentConfiguration(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
}