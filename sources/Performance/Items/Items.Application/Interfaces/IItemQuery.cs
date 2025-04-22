using Items.Application.Models.Views;

namespace Items.Application.Interfaces;

public interface IItemQuery
{
    IEnumerable<ItemView> GetItemViews();
    ItemView GetItem(string id);
}