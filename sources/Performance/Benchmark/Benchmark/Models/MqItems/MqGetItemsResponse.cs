using Common.MassTransit.Contracts.Items;

namespace Benchmark.Models.MqItems;

public record MqGetItemsResponse(IEnumerable<IMqItem> Items) : IMqGetItemsResponse;