using Items.Application.Interfaces;
using Items.Application.Interfaces.Persistence;
using Items.Application.Models.Dto;
using Items.Application.Models.Views;
using MapsterMapper;

namespace Items.Application.Queries;

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