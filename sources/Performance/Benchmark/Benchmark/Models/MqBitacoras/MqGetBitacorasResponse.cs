using Common.MassTransit.Contracts.Bitacoras;

namespace Benchmark.Models.MqBitacoras;

public record MqGetBitacorasResponse(IEnumerable<IMqBitacora> Bitacoras) : IMqGetBitacorasResponse;