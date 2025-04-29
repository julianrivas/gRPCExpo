namespace Common.MassTransit.Contracts.Bitacoras;

public interface IMqBitacora
{
    public Guid Guid { get; }
    public int IdEmpresa { get; }
    public int IdEmpleado { get; }
    public int? IdPeriodo { get; }
    public DateTime Fecha { get; }
    public short Dia { get; }
    public string IdItem { get; }
    public decimal DineroValor { get; }
    public int DineroMoneda { get; }
    public decimal Cantidad { get; }
    public int Unidad { get; }
    public decimal BaseDeCalculo { get; }
    public int PeriodicidadPago { get; }
    public bool FueraDeNomina { get; }
    public string Nit { get; }
    public string IdCentroCosto { get; }
    public int? IdPlanCuentaContable { get; }
    public int Estado { get; }
    public string Observacion { get; }
    public string TipoPeriodo { get; }
}