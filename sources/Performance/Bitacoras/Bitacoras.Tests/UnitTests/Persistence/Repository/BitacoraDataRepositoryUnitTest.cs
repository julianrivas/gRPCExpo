using Bitacoras.Application.Models.Dto;
using Bitacoras.Persistence.Context;
using Bitacoras.Persistence.Repositories;
using Common.HttpExceptions.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Bitacoras.Tests.UnitTests.Persistence.Repository;

public class BitacoraDataRepositoryTests
{
    private BitacorasContext CreateContextWithData(IEnumerable<BitacoraData> items)
    {
        var options = new DbContextOptionsBuilder<BitacorasContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()) // Cada test tiene su propia DB
            .Options;

        var context = new BitacorasContext(options);

        context.AddRange(items);
        context.SaveChanges();

        return context;
    }

    [Fact]
    public void ObtainBitacoraDataList_ShouldReturnAllBitacoras()
    {
        var fakeData = new List<BitacoraData>
        {
            new(new Guid("aecde61c-b22c-40ae-b1e0-2e3887fb1b99"), 1,1000,
                766, new DateTime(2023,04,01), 1,"P17",
                33333.33m, 1, 1, 1,
                0m, 0, false, "23351", null,
                null, 2,null, "N"),

            new(new Guid("8888c143-2c01-4956-b453-a4ab0a485d87"), 1,2000,
                766, new DateTime(2023,04,01), 1,"P17",
                66666.66m, 1, 1, 1,
                0m, 0, false, "23351", null,
                null, 2,null, "N"),
        };

        using var context = CreateContextWithData(fakeData);
        var repository = new BitacoraDataRepository(context);

        var result = repository.ObtainBitacoraDataList();

        Assert.Equal(2, result.Count());
    }

    [Fact]
    public void ObtainBitacoraData_ShouldReturnCorrectItem_WhenItemExists()
    {
        var fakeData = new List<BitacoraData>
        {
            new(new Guid("aecde61c-b22c-40ae-b1e0-2e3887fb1b99"), 1,1000, 
                766, new DateTime(2023,04,01), 1,"P17",
                33333.33m, 1, 1, 1,
                0m, 0, false, "23351", null,
                null, 2,null, "N"),

            new(new Guid("8888c143-2c01-4956-b453-a4ab0a485d87"), 1,2000,
                766, new DateTime(2023,04,01), 1,"P17",
                66666.66m, 1, 1, 1,
                0m, 0, false, "23351", null,
                null, 2,null, "N"),

            new(new Guid("38d01f69-e563-4819-9e66-5a4a1307131f"), 1,1000,
                766, new DateTime(2023,04,01), 1,"P17",
                99999.99m, 1, 1, 1,
                0m, 0, false, "23351", null,
                null, 2,null, "N"),

        };

        using var context = CreateContextWithData(fakeData);
        var repository = new BitacoraDataRepository(context);

        var result = repository
            .ObtainBitacoraData(new Guid("aecde61c-b22c-40ae-b1e0-2e3887fb1b99"));

        Assert.NotNull(result);
        Assert.Equal(new Guid("aecde61c-b22c-40ae-b1e0-2e3887fb1b99"), result.Guid);
    }

    [Fact]
    public void ObtainBitacoraData_ShouldThrowNotFoundException_WhenBitacoraDoesNotExist()
    {

        var fakeData = new List<BitacoraData>
        {
            new(new Guid("aecde61c-b22c-40ae-b1e0-2e3887fb1b99"), 1,1000,
                766, new DateTime(2023,04,01), 1,"P17",
                33333.33m, 1, 1, 1,
                0m, 0, false, "23351", null,
                null, 2, null, "N"),
        };

        using var context = CreateContextWithData(fakeData);
        var repository = new BitacoraDataRepository(context);

        var exception = Assert.Throws<NotFoundException>(() => 
            repository.ObtainBitacoraData(new Guid("8888c143-2c01-4956-b453-a4ab0a485d87")));

        Assert.Equal("The bitacora with guid 8888c143-2c01-4956-b453-a4ab0a485d87 does not exist.", exception.Message);
    }
}
