using Bitacoras.Application.Models.Views;

namespace Bitacoras.Application.Interfaces;

public interface IBitacoraQuery
{
    IEnumerable<BitacoraView> GetBitacoraViews();
    BitacoraView GetBitacora(Guid guid);
}