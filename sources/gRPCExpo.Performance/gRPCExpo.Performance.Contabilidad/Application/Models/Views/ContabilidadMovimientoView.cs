namespace gRPCExpo.Performance.Contabilidad.Application.Models.Views
{
    public record ContabilidadMovimientoView(
        Guid Guid,
        int IdEmpleado,
        int Anio,
        int Mes,
        int IdPeriodo,
        string TipoPeriodoLiquidacion,
        string IdItem,
        byte TipoDocumento,
        int IdPlanCuentaContable,
        string IdCentroCosto,
        byte Puc,
        string CuentaContable,
        decimal Debito,
        decimal Credito,
        string Nit,
        string NitCuentaPorPagar,
        string DiscriminadorCuentaPorPagar,
        byte Estado,
        int IdEmpresa,
        string IdNomina,
        decimal BaseImpuesto,
        byte Moneda);
}
