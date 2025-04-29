using Common.MassTransit.Contracts.Bitacoras;

namespace Benchmark.Models.MqBitacoras;

public record MqBitacora(
    Guid Guid,
    int IdEmpresa,
    int IdEmpleado,
    int? IdPeriodo,
    DateTime Fecha,
    short Dia,
    string IdItem,
    decimal DineroValor,
    int DineroMoneda,
    decimal Cantidad,
    int Unidad,
    decimal BaseDeCalculo,
    int PeriodicidadPago,
    bool FueraDeNomina,
    string Nit,
    string IdCentroCosto,
    int? IdPlanCuentaContable,
    int Estado,
    string Observacion,
    string TipoPeriodo) : IMqBitacora;
