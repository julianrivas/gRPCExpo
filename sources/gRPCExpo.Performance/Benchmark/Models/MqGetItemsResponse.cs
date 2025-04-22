using gRPC.Expo.Preformance.Messages.cs.mqContracts;

namespace Benchmark.Models;

public record MqGetItemsResponse(IEnumerable<IMqItem> Items) : IMqGetItemsResponse;