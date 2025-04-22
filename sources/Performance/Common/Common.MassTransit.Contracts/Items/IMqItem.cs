namespace Common.MassTransit.Contracts.Items;

public interface IMqItem
{
    string Id { get; }
    string Descripcion { get; }
    decimal Factor { get; }
    bool FueraDeNomina { get; }
    bool RequiereFondo { get; }
    decimal Orden { get; }
    bool AgruparEnLiquidacion { get; }
    DateTime FechaRegistro { get; }
    string IdUsuarioRegistro { get; }
    bool Activo { get; }
    bool GeneraCuentaPorPagar { get; }
}