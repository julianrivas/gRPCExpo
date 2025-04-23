using Common.MassTransit.Contracts.Items;

namespace Clients.API.Contracts;

public record MqItem(
    string Id,
    string Descripcion,
    decimal Factor,
    bool FueraDeNomina,
    bool RequiereFondo,
    decimal Orden,
    bool AgruparEnLiquidacion,
    DateTime FechaRegistro,
    string IdUsuarioRegistro,
    bool Activo,
    bool GeneraCuentaPorPagar) 
    : IMqItem;