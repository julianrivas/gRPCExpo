using Bitacoras.API.Consumers.Contracts;
using Bitacoras.Application.Interfaces;
using Bitacoras.Application.Models.Views;
using Common.MassTransit.Contracts.Bitacoras;
using MapsterMapper;
using MassTransit;

namespace Bitacoras.API.Consumers;

public class GetBitacorasConsumer(IBitacoraQuery query, IMapper mapper) : IConsumer<IMqGetBitacorasRequest>
{
    public async Task Consume(ConsumeContext<IMqGetBitacorasRequest> context)
    {
        IEnumerable<BitacoraView> bitacoras = query.GetBitacoraViews();
        IEnumerable<IMqBitacora> mqBitacoras = mapper.Map<IEnumerable<IMqBitacora>>(bitacoras);
        IMqGetBitacorasResponse response = new MqGetBitacorasResponse(mqBitacoras);
        await context.RespondAsync(response);
    }
}   