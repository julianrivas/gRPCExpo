using gRPCExpo.Performance.CalendariosBitacoras.Application.Models.Views;
using Microsoft.AspNetCore.Mvc;

namespace gRPCExpo.Performance.CalendariosBitacoras.Controllers;

[Route("[controller]")]
[ApiController]
public class BitacorasController : ControllerBase
{
    // GET: Items
    [HttpGet]
    public IEnumerable<BitacoraView> Get()
    {
        return new List<BitacoraView>();
    }

    // GET: Items/5
    [HttpGet("{id}")]
    public BitacoraView Get(int id)
    {
        return null;
    }

    // POST: Items
    [HttpPost]
    public void Post([FromBody] BitacoraView value)
    {
    }

    // PUT: Items/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] BitacoraView value)
    {
    }

    // DELETE: Items/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}