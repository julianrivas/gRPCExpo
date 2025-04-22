using Items.Application.Models.Dto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Items.Persistence.Context.ModelBuilders;

public class ItemDataModelBuilder : IEntityTypeConfiguration<ItemData>
{
    public void Configure(EntityTypeBuilder<ItemData> builder)
    {
        builder.ToTable("Items", "grpcexpo");
        builder.HasKey(item => item.Id);
        builder.Property(item => item.Id).HasColumnType("VARCHAR(10)");
        builder.Property(item => item.Descripcion).HasColumnType("VARCHAR(100)").IsRequired();
        builder.Property(item => item.Factor).HasColumnType("DECIMAL(7,5)");
        builder.Property(item => item.FueraDeNomina);
        builder.Property(item => item.RequiereFondo);
        builder.Property(item => item.Orden).HasColumnType("DECIMAL(10, 4)");
        builder.Property(item => item.AgruparEnLiquidacion);
        builder.Property(item => item.IdUsuarioRegistro).HasColumnType("VARCHAR(254)");
        builder.Property(item => item.FechaRegistro).HasColumnType("DATETIME2");
        builder.Property(item => item.Activo);
        builder.Property(item => item.GeneraCuentaPorPagar);
    }
}