using System;
using Bitacoras.Application.Interfaces;
using Bitacoras.Application.Interfaces.Persistence;
using Bitacoras.Application.Models.Dto;
using Bitacoras.Application.Models.Views;
using MapsterMapper;

namespace Bitacoras.Application.Queries;

public class BitacoraQuery(IBitacoraDataRepository repository, IMapper mapper) : IBitacoraQuery
{
    public IEnumerable<BitacoraView> GetBitacoraViews()
    {
        IEnumerable<BitacoraData> bitacoraDataList = repository.ObtainBitacoraDataList();

        return mapper.Map<IEnumerable<BitacoraView>>(bitacoraDataList);
    }

    public BitacoraView GetBitacora(Guid guid)
    {
        BitacoraData bitacoraData = repository.ObtainBitacoraData(guid);

        return mapper.Map<BitacoraView>(bitacoraData);
    }
}