using Benchmark;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Running;

var config = ManualConfig.Create(DefaultConfig.Instance)
    .AddExporter(HtmlExporter.Default)
    .AddDiagnoser(MemoryDiagnoser.Default); 

BenchmarkRunner.Run<ItemsMessagingBenchmark>(config);
BenchmarkRunner.Run<BitacorasMessagingBenchmark>(config);