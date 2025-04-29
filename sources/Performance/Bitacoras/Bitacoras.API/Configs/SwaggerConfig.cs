namespace Bitacoras.API.Configs;

public static class SwaggerConfig
{
    public static void AddSwagger(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
    }

    public static void UseSwaggerDevelopment(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
}