using gRPCExpo.Performance.Items.Application.Interfaces;
using gRPCExpo.Performance.Items.Application.Views;
using gRPCExpo.Performance.Items.Infrastructure.Data.Interfaces;
using gRPCExpo.Performance.Items.Infrastructure.Data.Models;
using MapsterMapper;

namespace gRPCExpo.Performance.Items.Application.Queries;

public class ItemQuery(IItemDataRepository repository, IMapper mapper) : IItemQuery
{
    public IEnumerable<ItemView> GetItemViews()
    {
        IEnumerable<ItemData> itemDataList = repository.ObtainItemDataList();

        return mapper.Map<IEnumerable<ItemView>>(itemDataList);
    }

    public ItemView GetItem(string id)
    {
        ItemData itemData = repository.ObtainItemData(id);

        return mapper.Map<ItemView>(itemData);
    }
}