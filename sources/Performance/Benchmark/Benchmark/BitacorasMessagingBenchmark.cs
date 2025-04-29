using Benchmark.Configurations;
using Benchmark.Models.MqBitacoras;
using BenchmarkDotNet.Attributes;
using Common.MassTransit.Contracts.Bitacoras;
using Grpc.Net.Client;
using gRPCExpo.Performance.Benchmark;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;

namespace Benchmark;

public class BitacorasMessagingBenchmark
{
    private IRequestClient<IMqGetBitacorasRequest>? _mqBitacorasClient;
    private BitacoraService.BitacoraServiceClient? _grpcBitacorasClient;

    private IBusControl _busControl;
    private GrpcChannel? _bitacorasChannel;

    [GlobalSetup]
    public async Task Setup()
    {
        var services = new ServiceCollection();

        services.AddMasstransitConfiguration();

        var provider = services.BuildServiceProvider();

        _busControl = provider.GetRequiredService<IBusControl>();

        await _busControl.StartAsync();

        _mqBitacorasClient = provider.GetRequiredService<IRequestClient<IMqGetBitacorasRequest>>();
        
        _bitacorasChannel = GrpcChannel.ForAddress("https://localhost:32773");
        _grpcBitacorasClient = new BitacoraService.BitacoraServiceClient(_bitacorasChannel);
    }

    [Benchmark(Description = "MassTransit - Get Bitacoras")]
    public async Task MassTransitBitacoras()
    {
        await _mqBitacorasClient
            .GetResponse<IMqGetBitacorasResponse>(new MqGetBitacorasRequest(),
                CancellationToken.None, RequestTimeout.Default);
    }


    [Benchmark(Description = "gRPC - Get Bitacoras")]
    public async Task GrpcBitacoras()
    {
        await _grpcBitacorasClient.GetBitacorasAsync(new BitacorasByEmptyRequest());
    }

    [GlobalCleanup]
    public async Task Cleanup()
    {
        if (_busControl != null)
            await _busControl.StopAsync();

        if (_bitacorasChannel != null)
            await _bitacorasChannel.ShutdownAsync();
    }
}