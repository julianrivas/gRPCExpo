using Mapster;

namespace Items.API.Configs
{
    public static class InfraConfig
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection servicios)
        {
            servicios.AddMapster();
            servicios.AddControllers();
            servicios.AddMasstransit();
            servicios.AddSwagger();

            return servicios;
        }
    }
}
