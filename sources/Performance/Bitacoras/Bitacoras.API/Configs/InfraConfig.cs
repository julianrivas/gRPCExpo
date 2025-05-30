﻿using Mapster;

namespace Bitacoras.API.Configs;

public static class InfraConfig
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection servicios)
    {
        servicios.AddMapster();
        servicios.AddControllers();
        servicios.AddMasstransit();
        servicios.AddGrpc();
        servicios.AddSwagger();

        return servicios;
    }
}