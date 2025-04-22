using Microsoft.Extensions.DependencyInjection;
using Items.Application.Interfaces;
using Items.Application.Queries;

namespace Items.Application;

public static class DependencyInjection
{
    public static void AddApplication(this IServiceCollection servicios)
    {
        servicios.AddScoped<IItemQuery, ItemQuery>();
    }
}