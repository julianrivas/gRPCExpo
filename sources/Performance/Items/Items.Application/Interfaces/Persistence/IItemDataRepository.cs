using Items.Application.Models.Dto;

namespace Items.Application.Interfaces.Persistence;

public interface IItemDataRepository
{
    IEnumerable<ItemData> ObtainItemDataList();
    ItemData ObtainItemData(string id);
}