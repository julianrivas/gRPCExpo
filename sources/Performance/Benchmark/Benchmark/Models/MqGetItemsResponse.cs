
using Common.MassTransit.Contracts.Items;

namespace Benchmark.Models;

public record MqGetItemsResponse(IEnumerable<IMqItem> Items) : IMqGetItemsResponse;