using Benchmark.Configurations;
using Benchmark.Models;
using BenchmarkDotNet.Attributes;
using Common.MassTransit.Contracts.Items;
using Grpc.Net.Client;
using gRPCExpo.Performance.Client;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;

namespace Benchmark;

public class MessagingBenchmark
{
    private IRequestClient<IMqGetItemsRequest> _mqClient;
    private ItemSevice.ItemSeviceClient _grpcClient;

    private IBusControl _busControl;
    private GrpcChannel _channel;

    [GlobalSetup]
    public async Task Setup()
    {
        // MassTransit (RabbitMQ or gRPC)
        var services = new ServiceCollection();

        services.AddMasstransitConfiguration();

        var provider = services.BuildServiceProvider();

        _busControl = provider.GetRequiredService<IBusControl>();
        await _busControl.StartAsync();

        _mqClient = provider.GetRequiredService<IRequestClient<IMqGetItemsRequest>>();

        // Raw gRPC client
        _channel = GrpcChannel.ForAddress("https://localhost:32807");
        _grpcClient = new ItemSevice.ItemSeviceClient(_channel);
    }

    [Benchmark]
    public async Task MassTransit()
    {
        await _mqClient
            .GetResponse<IMqGetItemsResponse>(new MqGetItemsRequest(), 
                CancellationToken.None, RequestTimeout.Default);
    }

    [Benchmark]
    public async Task Grpc()
    {
        await _grpcClient.GetItemsAsync(new ItemsByEmptyRequest());
    }

    [GlobalCleanup]
    public async Task Cleanup()
    {
        await _busControl.StopAsync();
        await _channel.ShutdownAsync();
    }
}