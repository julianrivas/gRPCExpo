using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using gRPCExpo.Performance.Items.Infrastructure.Data.Interfaces;
using gRPCExpo.Performance.Items.Infrastructure.Data.Models;

namespace gRPCExpo.Performance.Items.Presentation.Consumers.rpcConsumers;

public class ItemConsumer(IItemDataRepository repository, ILogger<ItemConsumer> logger) : ItemSevice.ItemSeviceBase
{
    public override Task<Item> GetItem(ItemByIdRequest request, ServerCallContext context)
    {
        logger.LogInformation("GetItem called with ID: {Id}", request.Id);
        ItemData itemData = repository.ObtainItemData(request.Id);

        var item = CreateItem(itemData);

        logger.LogInformation("Item retrieved: {Item}", item);
        
        return  Task.FromResult(item);
    }
    
    public override Task<ItemsResponse> GetItems(ItemsByEmptyRequest request, ServerCallContext context)
    {
        logger.LogInformation("GetItems called");

        IEnumerable<ItemData> itemsDataList = repository.ObtainItemDataList();

        List<Item> items = itemsDataList.Select(CreateItem).ToList();

        ItemsResponse response = new ()
        {
            Items = { items }
        };

        logger.LogInformation("Items retrieved: {ItemsCount}", items.Count);

        return Task.FromResult(response);
    }

    private static Item CreateItem(ItemData itemData)
    {
        Item item = new Item
        {
            Id = itemData.Id,
            Descripcion = itemData.Descripcion,
            Factor = (float)itemData.Factor,
            FueraDeNomina = itemData.FueraDeNomina,
            RequiereFondo = itemData.RequiereFondo,
            Orden = (float)itemData.Orden,
            AgruparEnLiquidacion = itemData.AgruparEnLiquidacion,
            FechaRegistro = Timestamp.FromDateTime(itemData.FechaRegistro.ToUniversalTime()),
            IdUsuarioRegistro = itemData.IdUsuarioRegistro,
            Activo = itemData.Activo,
            GeneraCuentaPorPagar = itemData.GeneraCuentaPorPagar
        };

        return item;
    }
}