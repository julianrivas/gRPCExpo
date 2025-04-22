using Common.HttpExceptions.Exceptions;
using Items.Application.Interfaces.Persistence;
using Items.Application.Models.Dto;
using Items.Persistence.Context;

namespace Items.Persistence.Repositories;

public class ItemDataRepository(ItemsContext context) : IItemDataRepository
{
    public IEnumerable<ItemData> ObtainItemDataList()
    {
        return context.ObtainUntrackedItemsData()
            .AsEnumerable();
    }

    public ItemData ObtainItemData(string id)
    {
        return context.ObtainUntrackedItemsData()
                   .FirstOrDefault(itm => itm.Id == id)
               ?? throw new NotFoundException($"The item with id {id} does not exist.");
    }
}