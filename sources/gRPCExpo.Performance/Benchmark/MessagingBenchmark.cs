using BenchmarkDotNet.Attributes;
using gRPC.Expo.Preformance.Messages.cs.mqContracts;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Benchmark.Configurations;
using Benchmark.Models;
using gRPCExpo.Performance.Client;
using Grpc.Net.Client;
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
        _channel = GrpcChannel.ForAddress("http://localhost:32779");
        _grpcClient = new ItemSevice.ItemSeviceClient(_channel);
    }

    [Benchmark]
    public async Task MassTransitGrpc()
    {
        var response = await _mqClient
            .GetResponse<IMqGetItemsResponse>(new MqGetItemsRequest(), 
                CancellationToken.None, RequestTimeout.Default);
    }

    [Benchmark]
    public async Task GrpcDirect()
    {
        var response = await _grpcClient.GetItemsAsync(new ItemsByEmptyRequest());
    }

    [GlobalCleanup]
    public async Task Cleanup()
    {
        await _busControl.StopAsync();
        await _channel.ShutdownAsync();
    }
}