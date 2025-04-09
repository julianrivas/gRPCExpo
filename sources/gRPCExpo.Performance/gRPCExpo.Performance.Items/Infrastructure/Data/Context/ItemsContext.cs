using gRPCExpo.Performance.Items.Infrastructure.Data.Context.ModelBuilders;
using gRPCExpo.Performance.Items.Infrastructure.Data.Context.Seeds;
using gRPCExpo.Performance.Items.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace gRPCExpo.Performance.Items.Infrastructure.Data.Context;

public class ItemsContext(DbContextOptions<ItemsContext> options) : DbContext(options)
{
    private DbSet<ItemData> Items { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ItemDataModelBuilder());
        modelBuilder.ApplyConfiguration(new ItemDataSeeder());
    }

    public IQueryable<ItemData> ObtainTrackedItemsData() => Items;
    public IQueryable<ItemData> ObtainUntrackedItemsData() => Items.AsNoTracking();
}