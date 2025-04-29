using Clients.API.Contracts.MqBitacoras;
using Common.MassTransit.Contracts.Items;
using Grpc.Net.Client;
using gRPCExpo.Performance.Clients;
using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace Clients.API.Controllers;

[Route("[controller]")]
[ApiController]
public class BitacorasController(IRequestClient<IMqGetItemsRequest> client) : ControllerBase
{
    [HttpGet("GetBitacorasMq")]
    public async Task<IActionResult> GetItemsMqAsync()
    {
        Response<IMqGetItemsResponse> response = await client.GetResponse<IMqGetItemsResponse>(new MqGetBitacorasRequest(), CancellationToken.None, RequestTimeout.Default);

        return Ok(response.Message.Items);
    }

    [HttpGet("GetBitacorasRpc")]
    public async Task<IActionResult> GetItemsRpcAsync()
    {
        HttpClientHandler handler = new HttpClientHandler()
        {
            ServerCertificateCustomValidationCallback = HttpClientHandler
                .DangerousAcceptAnyServerCertificateValidator
        };

        using GrpcChannel channel = GrpcChannel.ForAddress("https://192.168.20.48:32771",
            new GrpcChannelOptions { HttpHandler = handler });

        BitacoraService.BitacoraServiceClient seviceClient = new BitacoraService.BitacoraServiceClient(channel);
        BitacorasResponse response = await seviceClient.GetBitacorasAsync(new BitacorasByEmptyRequest());

        return Ok(response.Bitacoras);
    }
}