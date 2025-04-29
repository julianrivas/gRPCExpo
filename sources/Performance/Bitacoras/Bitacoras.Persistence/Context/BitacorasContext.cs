using Bitacoras.Application.Models.Dto;
using Bitacoras.Persistence.Context.ModelBuilders;
using Bitacoras.Persistence.Context.Seeds;
using Microsoft.EntityFrameworkCore;

namespace Bitacoras.Persistence.Context;

public class BitacorasContext(DbContextOptions<BitacorasContext> options) : DbContext(options)
{
    private DbSet<BitacoraData> Bitacoras { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new BitacoraDataModelBuilder());
        modelBuilder.ApplyConfiguration(new BitacoraDataSeeder());
    }

    public IQueryable<BitacoraData> ObtainTrackedItemsData() => Bitacoras;
    public IQueryable<BitacoraData> ObtainUntrackedItemsData() => Bitacoras.AsNoTracking();
}