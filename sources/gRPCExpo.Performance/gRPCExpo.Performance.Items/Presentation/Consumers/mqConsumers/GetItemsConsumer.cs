using gRPC.Expo.Preformance.Messages.cs.mqContracts;
using gRPCExpo.Performance.Items.Application.Interfaces;
using gRPCExpo.Performance.Items.Application.Views;
using gRPCExpo.Performance.Items.Presentation.Contracts;
using MapsterMapper;
using MassTransit;

namespace gRPCExpo.Performance.Items.Presentation.Consumers.mqConsumers;

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