using Common.MassTransit.Contracts.Items;

namespace Items.API.Consumers.Contracts;

public record MqGetItemsResponse(IEnumerable<IMqItem> Items) : IMqGetItemsResponse;