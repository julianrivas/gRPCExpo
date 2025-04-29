using Clients.API.Contracts;
using Clients.API.Contracts.MqItems;
using Common.MassTransit.Contracts.Items;
using Grpc.Net.Client;
using gRPCExpo.Performance.Client;
using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace Clients.API.Controllers;

[Route("[controller]")]
[ApiController]
public class ItemsController(IRequestClient<IMqGetItemsRequest> client) : ControllerBase
{
    [HttpGet("GetItemsMq")]
    public async Task<IActionResult> GetItemsMqAsync()
    {
        Response<IMqGetItemsResponse> response = await client.GetResponse<IMqGetItemsResponse>(new MqGetItemsRequest(), CancellationToken.None, RequestTimeout.Default);

        return Ok(response.Message.Items);
    }

    [HttpGet("GetItemsRpc")]
    public async Task<IActionResult> GetItemsRpcAsync()
    {
        HttpClientHandler handler = new HttpClientHandler()
        {
            ServerCertificateCustomValidationCallback = HttpClientHandler
                .DangerousAcceptAnyServerCertificateValidator
        };

        using GrpcChannel channel = GrpcChannel.ForAddress("https://192.168.20.48:32783",
            new GrpcChannelOptions { HttpHandler = handler });

        ItemService.ItemServiceClient seviceClient = new ItemService.ItemServiceClient(channel);
        ItemsResponse response = await seviceClient.GetItemsAsync(new ItemsByEmptyRequest());

        return Ok(response.Items);
    }
}