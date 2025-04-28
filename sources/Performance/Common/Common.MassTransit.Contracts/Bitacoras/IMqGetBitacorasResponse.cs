using Common.MassTransit.Contracts.Items;

namespace Common.MassTransit.Contracts.Bitacoras;

public interface IMqGetBitacorasResponse
{
    IEnumerable<IMqItem> Bitacoras { get; }
}