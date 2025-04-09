using gRPCExpo.Performance.Exceptions.Http;
using gRPCExpo.Performance.Items.Infrastructure.Data.Context;
using gRPCExpo.Performance.Items.Infrastructure.Data.Interfaces;
using gRPCExpo.Performance.Items.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace gRPCExpo.Performance.Items.Infrastructure.Data.Repository;

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