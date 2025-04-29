using System;
using Common.HttpExceptions.Exceptions;
using Microsoft.EntityFrameworkCore;
using Items.Application.Models.Dto;
using Items.Persistence.Context;
using Items.Persistence.Repositories;

namespace Items.Tests.UnitTests.Persistence.Repository;

public class ItemDataRepositoryTests
{
    private ItemsContext CreateContextWithData(IEnumerable<ItemData> items)
    {
        var options = new DbContextOptionsBuilder<ItemsContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()) // Cada test tiene su propia DB
            .Options;

        var context = new ItemsContext(options);

        context.AddRange(items);
        context.SaveChanges();

        return context;
    }

    [Fact]
    public void ObtainItemDataList_ShouldReturnAllItems()
    {
        var fakeData = new List<ItemData>
        {
            new ("ITM1", "Item 1", 
                1, false, true, 
                1, false, new DateTime(2025, 4, 1), 
                "user@company.com", true, false),
            new ("ITM2", "Item 2", 
                1, false, true, 
                1, false, new DateTime(2025, 4, 1), 
                "user@company.com", true, false)
        };

        using var context = CreateContextWithData(fakeData);
        var repository = new ItemDataRepository(context);

        var result = repository.ObtainItemDataList();

        Assert.Equal(2, result.Count());
    }

    [Fact]
    public void ObtainItemData_ShouldReturnCorrectItem_WhenItemExists()
    {
        var fakeData = new List<ItemData>
        {
            new ("ITM1", "Item 1",
                1, false, true,
                1, false, new DateTime(2025, 4, 1),
                "user@company.com", true, false),
            new ("ITM2", "Item 2",
                1, false, true,
                1, false, new DateTime(2025, 4, 1),
                "user@company.com", true, false)
        };

        using var context = CreateContextWithData(fakeData);
        var repository = new ItemDataRepository(context);

        var result = repository.ObtainItemData("ITM2");

        Assert.NotNull(result);
        Assert.Equal("ITM2", result.Id);
    }

    [Fact]
    public void ObtainItemData_ShouldThrowNotFoundException_WhenItemDoesNotExist()
    {
        var fakeData = new List<ItemData>
        {
            new ("ITM1", "Item 1",
                1, false, true,
                1, false, new DateTime(2025, 4, 1),
                "user@company.com", true, false)
        };

        using var context = CreateContextWithData(fakeData);
        var repository = new ItemDataRepository(context);

        var exception = Assert.Throws<NotFoundException>(() => 
            repository.ObtainItemData("999"));

        Assert.Equal("The item with id 999 does not exist.", exception.Message);
    }
}
