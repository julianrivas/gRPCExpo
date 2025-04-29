using Items.Application.Models.Views;

namespace Bitacoras.Application.Queries;

public interface IItemQuery
{
    IEnumerable<ItemView> GetBitacoraViews();
    ItemView GetBitacora(Guid guid);
}