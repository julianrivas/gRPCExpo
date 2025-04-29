using Bitacoras.Application.Models.Dto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bitacoras.Persistence.Context.ModelBuilders;

public class BitacoraDataModelBuilder : IEntityTypeConfiguration<BitacoraData>
{
    public void Configure(EntityTypeBuilder<BitacoraData> builder)
    {
        builder.ToTable("Bitacoras", "grpcexpo");
        builder.HasKey(x => new
        {
            x.IdEmpresa, 
            x.IdEmpleado, 
            x.Fecha, 
            x.Dia, 
            x.Guid
        });

        builder.Property(p => p.IdEmpresa)
               .IsRequired();

        builder.Property(p => p.IdEmpleado)
               .IsRequired();

        builder.Property(p => p.IdPeriodo);
        builder.Property(p => p.TipoPeriodo)
               .IsRequired()
               .HasColumnType("VARCHAR(2)");

        builder.Property(p => p.Fecha)
               .IsRequired()
               .HasColumnType("DATE");

        builder.Property(op => op.IdItem)
         .IsRequired()
         .HasColumnType("VARCHAR(10)");

        builder.Property(od => od.DineroValor)
         .IsRequired()
         .HasColumnType("DECIMAL(28, 18)");


        builder.Property(p => p.DineroMoneda)
            .IsRequired();

        builder.Property(ot => ot.Cantidad)
         .IsRequired()
         .HasColumnType("DECIMAL(6, 2)");

        builder.Property(ot => ot.Unidad)
         .IsRequired();

        builder.Property(od => od.BaseDeCalculo)
         .IsRequired()
         .HasColumnType("DECIMAL(28, 18)");

        builder.Property(p => p.Estado)
               .IsRequired();
        builder.Property(p => p.Dia)
               .IsRequired();
        builder.Property(p => p.PeriodicidadPago)
               .IsRequired();
        builder.Property(p => p.Observacion)
               .HasColumnType("VARCHAR(500)");
        builder.Property(p => p.FueraDeNomina)
               .IsRequired();

        builder.Property(oi => oi.Nit)
         .HasColumnType("NVARCHAR(80)");

        builder.Property(oi => oi.IdCentroCosto)
         .HasColumnType("VARCHAR(30)");

        builder.Property(oi => oi.IdPlanCuentaContable);

        builder.HasIndex(b => new
        {
            b.IdEmpresa, 
            b.IdEmpleado, 
            b.Fecha, 
            b.IdItem
        });

        builder.HasIndex(b => new
        {
            b.IdEmpresa, 
            b.IdPeriodo
        });

        builder.HasIndex(p => new
        {
            p.IdEmpresa, 
            p.IdEmpleado, 
            p.TipoPeriodo, 
            p.Fecha
        });
    }
}