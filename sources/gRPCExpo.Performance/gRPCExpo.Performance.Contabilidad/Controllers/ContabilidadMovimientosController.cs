using gRPCExpo.Performance.Contabilidad.Application.Models.Views;
using Microsoft.AspNetCore.Mvc;

namespace gRPCExpo.Performance.Contabilidad.Controllers;

[Route("[controller]")]
[ApiController]
public class ContabilidadMovimientosController : ControllerBase
{
    // GET: Items
    [HttpGet]
    public IEnumerable<ContabilidadMovimientoView> Get()
    {
        return new List<ContabilidadMovimientoView>();
    }

    // GET: Items/5
    [HttpGet("{id}")]
    public ContabilidadMovimientoView Get(int id)
    {
        return null;
    }

    // POST: Items
    [HttpPost]
    public void Post([FromBody] ContabilidadMovimientoView value)
    {
    }

    // PUT: Items/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] ContabilidadMovimientoView value)
    {
    }

    // DELETE: Items/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}