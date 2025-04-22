using Items.Application.Models.Dto;
using Items.Persistence.Context.ModelBuilders;
using Items.Persistence.Context.Seeds;
using Microsoft.EntityFrameworkCore;

namespace Items.Persistence.Context;

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