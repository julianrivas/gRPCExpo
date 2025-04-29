using Common.MassTransit.Contracts.Bitacoras;

namespace Bitacoras.API.Consumers.Contracts;

public record MqGetBitacorasResponse(IEnumerable<IMqBitacora> Bitacoras) : IMqGetBitacorasResponse;