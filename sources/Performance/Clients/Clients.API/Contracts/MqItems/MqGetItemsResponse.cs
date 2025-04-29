using Common.MassTransit.Contracts.Items;

namespace Clients.API.Contracts.MqItems;

public record MqGetItemsResponse(IEnumerable<IMqItem> Items) : IMqGetItemsResponse;