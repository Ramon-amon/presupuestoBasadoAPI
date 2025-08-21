using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using presupuestoBasadoAPI.Data;
using presupuestoBasadoAPI.Models;

[ApiController]
[Route("api/[controller]")]
public class RamoController : ControllerBase
{
    private readonly AppDbContext _context;

    public RamoController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Ramo>>> Get()
    {
        return await _context.Ramos.ToListAsync();
    }

    [HttpPost]
    public async Task<ActionResult<Ramo>> Post(Ramo ramo)
    {
        _context.Ramos.Add(ramo);
        await _context.SaveChangesAsync();
        return Ok(ramo);
    }

    [HttpGet("ultimo")]
    public async Task<ActionResult<Ramo>> GetUltimo()
    {
        var ultimo = await _context.Ramos
            .OrderByDescending(x => x.Id)
            .FirstOrDefaultAsync();

        if (ultimo == null) return NotFound();
        return Ok(ultimo);
    }

}
