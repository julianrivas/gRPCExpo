using Clients.API.Contracts;
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
    [HttpGet]
    public IActionResult GetStatus()
    {
        return Ok("Api running...");
    }

    [HttpGet("GetItemsMqAsync")]
    public async Task<IActionResult> GetItemsMqAsync()
    {
        Response<IMqGetItemsResponse> response = await client.GetResponse<IMqGetItemsResponse>(new MqGetItemsRequest(), CancellationToken.None, RequestTimeout.Default);

        return Ok(response.Message.Items);
    }

    [HttpGet("GetItemsRpcAsync")]
    public async Task<IActionResult> GetItemsRpcAsync()
    {
        HttpClientHandler handler = new HttpClientHandler()
        {
            ServerCertificateCustomValidationCallback = HttpClientHandler
                .DangerousAcceptAnyServerCertificateValidator
        };

        using GrpcChannel channel = GrpcChannel.ForAddress("https://192.168.20.48:32807",
            new GrpcChannelOptions { HttpHandler = handler });

        ItemSevice.ItemSeviceClient seviceClient = new ItemSevice.ItemSeviceClient(channel);
        ItemsResponse response = await seviceClient.GetItemsAsync(new ItemsByEmptyRequest());

        return Ok(response.Items);
    }
}