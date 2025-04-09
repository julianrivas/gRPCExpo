using gRPC.Expo.Preformance.Messages.cs.mqContracts;
using Grpc.Net.Client;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using gRPCExpo.Performance.Client.Models;

namespace gRPCExpo.Performance.Client.Controllers;

[Route("[controller]")]
[ApiController]
public class MqItemsController(IRequestClient<IMqGetItemsRequest> client) : ControllerBase
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
        HttpClientHandler handler = new ();

        handler.ServerCertificateCustomValidationCallback = HttpClientHandler
            .DangerousAcceptAnyServerCertificateValidator;

        using GrpcChannel channel = GrpcChannel.ForAddress("http://localhost:32773",
            new GrpcChannelOptions { HttpHandler = handler });

        ItemSevice.ItemSeviceClient seviceClient = new ItemSevice.ItemSeviceClient(channel);
        ItemsResponse response = await seviceClient.GetItemsAsync(new ItemsByEmptyRequest());

        return Ok(response.Items);
    }
}