using Common.MassTransit.Contracts.Bitacoras;

namespace Clients.API.Contracts.MqBitacoras;

public record MqGetBitacorasResponse(IEnumerable<IMqBitacora> Bitacoras) : IMqGetBitacorasResponse;