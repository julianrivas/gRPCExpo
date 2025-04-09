namespace gRPCExpo.Performance.CalendariosBitacoras.Application.Models.Views;

public record BitacoraView(
    Guid Guid,
    int IdEmpleado,
    DateTime Fecha,
    short Dia,
    string IdItem,
    decimal Dinero,
    byte Tiempo,
    string Evento,
    decimal BaseDeCalculo,
    byte PeriodicidadPago,
    byte Moneda,
    bool FueraDeNomina,
    string Nit,
    string IdCentroCosto,
    int? IdPlanCuentaContable,
    int? IdPeriodo,
    byte Estado,
    string Observacion,
    string TipoPeriodo,
    int IdEmpresa);



