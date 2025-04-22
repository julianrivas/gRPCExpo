using Common.MassTransit.Contracts.Items;
using Items.API.Consumers.Contracts;
using Items.Application.Interfaces;
using Items.Application.Models.Views;
using MapsterMapper;
using MassTransit;

namespace Items.API.Consumers;

public class GetItemsConsumer(IItemQuery query, IMapper mapper) : IConsumer<IMqGetItemsRequest>
{
    public async Task Consume(ConsumeContext<IMqGetItemsRequest> context)
    {
        IEnumerable<ItemView> items = query.GetItemViews();
        IEnumerable<IMqItem> mqItems = mapper.Map<IEnumerable<IMqItem>>(items);
        IMqGetItemsResponse response = new MqGetItemsResponse(mqItems);
        await context.RespondAsync(response);
    }
}   