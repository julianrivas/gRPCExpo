using System.Text.Json;
using Items.Application.Models.Dto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Items.Persistence.Context.Seeds;

public class ItemDataSeeder : IEntityTypeConfiguration<ItemData>
{
    public void Configure(EntityTypeBuilder<ItemData> builder)
    {
        builder.HasData(LoadSeedData(Path.Combine(AppContext.BaseDirectory, 
            "Context", "Seeds", "ItemsData.json")));
    }

    private List<ItemData> LoadSeedData(string seedData)
    {
        var jsonData = File.ReadAllText(seedData) 
            ?? throw new InvalidOperationException("The JSON file does not exist.");

        return JsonSerializer.Deserialize<List<ItemData>>(jsonData) 
            ?? throw new InvalidOperationException("The JSON file is empty.");
    }
}