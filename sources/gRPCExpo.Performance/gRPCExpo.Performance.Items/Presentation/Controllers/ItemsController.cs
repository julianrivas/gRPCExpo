using gRPCExpo.Performance.Items.Application.Interfaces;
using gRPCExpo.Performance.Items.Application.Views;
using Microsoft.AspNetCore.Mvc;

namespace gRPCExpo.Performance.Items.Presentation.Controllers;

[Route("[controller]")]
[ApiController]
public class ItemsController(IItemQuery query) : ControllerBase
{
    // GET: Items
    [HttpGet]
    public IEnumerable<ItemView> Get()
    {
        return query.GetItemViews();
    }

    // GET: Items/5
    [HttpGet("{id}")]
    public ItemView Get(string id)
    {
        return query.GetItem(id);
    }

    // POST: Items
    [HttpPost]
    public void Post([FromBody] ItemView value)
    {
        throw new NotImplementedException();
    }

    // PUT: Items/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] ItemView value)
    {
        throw new NotImplementedException();
    }

    // DELETE: Items/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
        throw new NotImplementedException();
    }
}