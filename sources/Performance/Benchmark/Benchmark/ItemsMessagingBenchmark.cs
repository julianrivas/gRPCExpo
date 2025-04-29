using Benchmark.Configurations;
using Benchmark.Models.MqItems;
using BenchmarkDotNet.Attributes;
using Common.MassTransit.Contracts.Items;
using Grpc.Net.Client;
using gRPCExpo.Performance.Benckmark;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;

namespace Benchmark;

public class ItemsMessagingBenchmark
{
    private IRequestClient<IMqGetItemsRequest>? _mqItemsClient;
    private ItemService.ItemServiceClient? _grpcItemsClient;

    private IBusControl _busControl;
    private GrpcChannel? _itemsChannel;

    [GlobalSetup]
    public async Task Setup()
    {
        var services = new ServiceCollection();

        services.AddMasstransitConfiguration();

        var provider = services.BuildServiceProvider();

        _busControl = provider.GetRequiredService<IBusControl>();

        await _busControl.StartAsync();

        _mqItemsClient = provider.GetRequiredService<IRequestClient<IMqGetItemsRequest>>();

        _itemsChannel = GrpcChannel.ForAddress("https://localhost:32771");

        _grpcItemsClient = new ItemService.ItemServiceClient(_itemsChannel);
    }

    [Benchmark(Description = "MassTransit - Get Items")]
    public async Task MassTransitItems()
    {
        await _mqItemsClient
            .GetResponse<IMqGetItemsResponse>(new MqGetItemsRequest(),
                CancellationToken.None, RequestTimeout.Default);
    }

    [Benchmark(Description = "gRPC - Get Items")]
    public async Task GrpcItems()
    {
        await _grpcItemsClient.GetItemsAsync(new ItemsByEmptyRequest());
    }

    [GlobalCleanup]
    public async Task Cleanup()
    {
        if (_busControl != null)
            await _busControl.StopAsync();

        if (_itemsChannel != null)
            await _itemsChannel.ShutdownAsync();
    }
}