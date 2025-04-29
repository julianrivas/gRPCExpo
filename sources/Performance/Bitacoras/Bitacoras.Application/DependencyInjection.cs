using Bitacoras.Application.Interfaces;
using Bitacoras.Application.Queries;
using Microsoft.Extensions.DependencyInjection;

namespace Bitacoras.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection servicios)
    {
        servicios.AddScoped<IBitacoraQuery, BitacoraQuery>();

        return servicios;
    }
}