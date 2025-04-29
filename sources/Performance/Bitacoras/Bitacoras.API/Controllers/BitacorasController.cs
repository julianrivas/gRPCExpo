using Bitacoras.Application.Interfaces;
using Bitacoras.Application.Models.Views;
using Microsoft.AspNetCore.Mvc;

namespace Bitacoras.API.Controllers;

[Route("[controller]")]
[ApiController]
public class BitacorasController(IBitacoraQuery query) : ControllerBase
{
    // GET: Bitacoras
    [HttpGet]
    public IEnumerable<BitacoraView> Get()
    {
        return query.GetBitacoraViews();
    }

    // GET: Bitacoras/5
    [HttpGet("{id}")]
    public BitacoraView Get(Guid id)
    {
        return query.GetBitacora(id);
    }

    // POST: Bitacoras
    [HttpPost]
    public void Post([FromBody] BitacoraView value)
    {
        throw new NotImplementedException();
    }

    // PUT: Bitacoras/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] BitacoraView value)
    {
        throw new NotImplementedException();
    }

    // DELETE: Bitacoras/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
        throw new NotImplementedException();
    }
}