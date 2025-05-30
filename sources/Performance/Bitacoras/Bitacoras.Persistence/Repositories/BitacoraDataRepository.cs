﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bitacoras.Application.Interfaces.Persistence;
using Bitacoras.Application.Models.Dto;
using Bitacoras.Persistence.Context;
using Common.HttpExceptions.Exceptions;

namespace Bitacoras.Persistence.Repositories;

public class BitacoraDataRepository(BitacorasContext context) :   IBitacoraDataRepository 
{
    public IEnumerable<BitacoraData> ObtainBitacoraDataList()
    {
        return context.ObtainUntrackedBitacorasData()
            .Where(bitacora => bitacora.IdEmpresa == 1) 
            .AsEnumerable();
    }

    public BitacoraData ObtainBitacoraData(Guid guid)
    {
        return context.ObtainUntrackedBitacorasData()
                   .FirstOrDefault(itm => itm.Guid == guid)
               ?? throw new NotFoundException($"The bitacora with guid {guid} does not exist.");
    }
}