using Common.MassTransit.Contracts.Items;

namespace Clients.API.Contracts;

public record MqGetItemsResponse(IEnumerable<IMqItem> Items) : IMqGetItemsResponse;