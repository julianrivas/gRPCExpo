using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using Bitacoras.Application.Models.Dto;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bitacoras.Persistence.Context.Seeds
{
    public class BitacoraDataSeeder : IEntityTypeConfiguration<BitacoraData>
    {
        public void Configure(EntityTypeBuilder<BitacoraData> builder)
        {
            builder.HasData(LoadSeedData(Path.Combine(AppContext.BaseDirectory,
                "Context", "Seeds", "BitacoraData.json")));
        }

        private List<BitacoraData> LoadSeedData(string seedData)
        {
            var jsonData = File.ReadAllText(seedData)
                           ?? throw new InvalidOperationException("The JSON file does not exist.");

            return JsonSerializer.Deserialize<List<BitacoraData>>(jsonData)
                   ?? throw new InvalidOperationException("The JSON file is empty.");
        }
    }
}
