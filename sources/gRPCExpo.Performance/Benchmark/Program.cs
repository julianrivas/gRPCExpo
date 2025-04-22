using Benchmark.Configurations;
using Benchmark.Models;
using BenchmarkDotNet.Running;
using gRPC.Expo.Preformance.Messages.cs.mqContracts;
using Grpc.Net.Client;
using gRPCExpo.Performance.Client;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Benchmark;

internal class Program
{
    static void Main(string[] args)
    {
        BenchmarkRunner.Run<MessagingBenchmark>();
    }

    //private static async Task GetMassTranssitItems(string[] args)
    //{
    //    var host = Host.CreateDefaultBuilder(args)
    //        .ConfigureServices(services =>
    //        {
    //            services.AddMasstransitConfiguration();
    //        })
    //        .Build();

    //    await host.StartAsync();

    //    var client = host.Services.GetRequiredService<IRequestClient<IMqGetItemsRequest>>();

    //    var response = await client.GetResponse<IMqGetItemsResponse>(new MqGetItemsRequest(), CancellationToken.None, RequestTimeout.Default);

    //    foreach (var item in response.Message.Items)
    //    {
    //        Console.WriteLine($"Received product: {item.Id} Description: {item.Descripcion}.");
    //    }

    //    await host.StopAsync();
    //}

    //private static async Task GetGrpcItems()
    //{
    //    using GrpcChannel channel = GrpcChannel.ForAddress("http://localhost:32769");

    //    ItemSevice.ItemSeviceClient seviceClient = new ItemSevice.ItemSeviceClient(channel);
    //    ItemsResponse response = await seviceClient.GetItemsAsync(new ItemsByEmptyRequest());

    //    foreach (var item in response.Items)
    //    {
    //        Console.WriteLine($"Received product: {item.Id} Description: {item.Descripcion}.");
    //    }
    //}
}