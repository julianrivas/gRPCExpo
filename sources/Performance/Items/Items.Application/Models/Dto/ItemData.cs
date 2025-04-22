namespace Items.Application.Models.Dto;

public class ItemData(
    string id,
    string descripcion,
    decimal factor,
    bool fueraDeNomina,
    bool requiereFondo,
    decimal orden,
    bool agruparEnLiquidacion,
    DateTime fechaRegistro,
    string idUsuarioRegistro,
    bool activo,
    bool generaCuentaPorPagar)
{
    public string Id { get; init; } = id;
    public string Descripcion { get; init; } = descripcion;
    public decimal Factor { get; init; } = factor;
    public bool FueraDeNomina { get; init; } = fueraDeNomina;
    public bool RequiereFondo { get; init; } = requiereFondo;
    public decimal Orden { get; init; } = orden;
    public bool AgruparEnLiquidacion { get; init; } = agruparEnLiquidacion;
    public DateTime FechaRegistro { get; init; } = fechaRegistro;
    public string IdUsuarioRegistro { get; init; } = idUsuarioRegistro;
    public bool Activo { get; init; } = activo;
    public bool GeneraCuentaPorPagar { get; init; } = generaCuentaPorPagar;
}