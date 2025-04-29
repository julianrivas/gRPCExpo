using Bitacoras.Application.Models.Dto;

namespace Bitacoras.Application.Interfaces.Persistence;

public interface IBitacoraDataRepository
{
    IEnumerable<BitacoraData> ObtainBitacoraDataList();
    BitacoraData ObtainBitacoraData(Guid guid);
}