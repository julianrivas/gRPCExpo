using Common.MassTransit.Contracts.Items;

namespace Common.MassTransit.Contracts.Bitacoras;

public interface IMqGetBitacorasResponse
{
    IEnumerable<IMqBitacora> Bitacoras { get; }
}