using Bitacoras.Application.Interfaces.Persistence;
using Bitacoras.Application.Models.Dto;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using gRPCExpo.Performance.Bitacoras;

namespace Bitacoras.API.Services;

public class BitacoraConsumer(IBitacoraDataRepository repository, ILogger<BitacoraConsumer> logger) : BitacoraSevice.BitacoraSeviceBase
{
    public override Task<Bitacora> GetBitacora(BitacoraByIdRequest request, ServerCallContext context)
    {
        logger.LogInformation("GetItem called with ID: {Id}", request.Id);
        BitacoraData itemData = repository.ObtainBitacoraData(new Guid(request.Id));

        Bitacora bitacora = CreateBitacora(itemData);

        logger.LogInformation("Bitacora retrieved: {Bitacora}", bitacora);
        
        return  Task.FromResult(bitacora);
    }
    
    public override Task<BitacorasResponse> GetBitacoras(BitacorasByEmptyRequest request, ServerCallContext context)
    {
        logger.LogInformation("GetItems called");

        IEnumerable<BitacoraData> bitacoraDataList = repository.ObtainBitacoraDataList();

        List<Bitacora> bitacoras = bitacoraDataList.Select(CreateBitacora).ToList();

        BitacorasResponse response = new ()
        {
            Bitacoras = { bitacoras }
        };

        logger.LogInformation("Items retrieved: {ItemsCount}", bitacoras.Count);

        return Task.FromResult(response);
    }

    private static Bitacora CreateBitacora(BitacoraData itemData)
    {
        Bitacora item = new Bitacora
        {
            Guid = itemData.Guid.ToString(),
            IdEmpresa = itemData.IdEmpresa,
            IdEmpleado = itemData.IdEmpleado,
            IdPeriodo = itemData.IdPeriodo.Value,
            Fecha = Timestamp.FromDateTime(itemData.Fecha.ToUniversalTime()),
            Dia = itemData.Dia,
            IdItem = itemData.IdItem,
            DineroValor = (float)itemData.DineroValor,
            DineroMoneda = (uint)itemData.DineroMoneda,
            Cantidad = (float)itemData.Cantidad,
            Unidad = (uint)itemData.Unidad,
            BaseDeCalculo = (float)itemData.BaseDeCalculo,
            PeriodicidadPago = (uint)itemData.PeriodicidadPago,
            FueraDeNomina = itemData.FueraDeNomina,
            Nit = itemData.Nit,
            IdCentroCosto = itemData.IdCentroCosto,
            IdPlanCuentaContable = itemData.IdPlanCuentaContable.Value,
            Estado = (uint)itemData.Estado,
            Observacion = itemData.Observacion,
            TipoPeriodo = itemData.TipoPeriodo
        };

        return item;
    }
}