namespace gRPCExpo.Performance.Items.Application.Views;

public record ItemView(
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
    bool GeneraCuentaPorPagar);