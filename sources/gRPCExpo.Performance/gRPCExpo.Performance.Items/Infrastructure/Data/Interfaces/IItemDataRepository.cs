using gRPCExpo.Performance.Items.Infrastructure.Data.Models;

namespace gRPCExpo.Performance.Items.Infrastructure.Data.Interfaces;

public interface IItemDataRepository
{
    IEnumerable<ItemData> ObtainItemDataList();
    ItemData ObtainItemData(string id);
}