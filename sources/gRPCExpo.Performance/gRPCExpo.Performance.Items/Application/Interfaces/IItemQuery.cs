using gRPCExpo.Performance.Items.Application.Views;

namespace gRPCExpo.Performance.Items.Application.Interfaces;

public interface IItemQuery
{
    IEnumerable<ItemView> GetItemViews();
    ItemView GetItem(string id);
}