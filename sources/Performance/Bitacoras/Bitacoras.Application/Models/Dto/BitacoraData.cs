namespace Bitacoras.Application.Models.Dto;

public class BitacoraData
{
    public BitacoraData(
        Guid guid, 
        int idEmpresa, 
        int idEmpleado, 
        int? idPeriodo, 
        DateTime fecha, 
        short dia, 
        string idItem, 
        decimal dineroValor, 
        int dineroMoneda, 
        decimal cantidad, 
        int unidad, 
        decimal baseDeCalculo, 
        int periodicidadPago,
        bool fueraDeNomina, 
        string nit, 
        string? idCentroCosto, 
        int? idPlanCuentaContable,
        int estado, 
        string? observacion, 
        string tipoPeriodo)
    {
        Guid = guid;
        IdEmpresa = idEmpresa;
        IdEmpleado = idEmpleado;
        IdPeriodo = idPeriodo;
        Fecha = fecha;
        Dia = dia;
        IdItem = idItem;
        DineroValor = dineroValor;
        DineroMoneda = dineroMoneda;
        Cantidad = cantidad;
        Unidad = unidad;
        BaseDeCalculo = baseDeCalculo;
        PeriodicidadPago = periodicidadPago;
        FueraDeNomina = fueraDeNomina;
        Nit = nit;
        IdCentroCosto = idCentroCosto;
        IdPlanCuentaContable = idPlanCuentaContable;
        Estado = estado;
        Observacion = observacion;
        TipoPeriodo = tipoPeriodo;
    }

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
    public string? IdCentroCosto { get; }
    public int? IdPlanCuentaContable { get; }
    public int Estado { get; }
    public string? Observacion { get; }
    public string TipoPeriodo { get; }
}