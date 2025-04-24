using System.Reflection;
using Common.MassTransit.Contracts.Items;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;

namespace Benchmark.Configurations;

public static class MasstransitConfig
{
    public static void AddMasstransitConfiguration(this IServiceCollection services)
    {
        services.AddMassTransit(x =>
        {
            x.SetKebabCaseEndpointNameFormatter();

            x.SetInMemorySagaRepositoryProvider();

            var entryAssembly = Assembly.GetEntryAssembly();

            x.AddConsumers(entryAssembly);
            x.AddSagaStateMachines(entryAssembly);
            x.AddSagas(entryAssembly);
            x.AddActivities(entryAssembly);

            x.AddRequestClient<IMqGetItemsRequest>();

            x.UsingRabbitMq((cxt, cfg) =>
            {
                cfg.Host("192.168.20.48", "/grpcexpo", h =>
                {
                    h.Username("guest");
                    h.Password("guest");
                });

                cfg.ConfigureEndpoints(cxt);
            });
        });
    }
}