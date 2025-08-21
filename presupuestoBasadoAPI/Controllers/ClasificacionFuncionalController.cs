using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using presupuestoBasadoAPI.Data;
using presupuestoBasadoAPI.Models;

[ApiController]
[Route("api/[controller]")]
public class ClasificacionFuncionalController : ControllerBase
{
    private readonly AppDbContext _context;

    public ClasificacionFuncionalController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ClasificacionFuncional>>> Get()
    {
        return await _context.ClasificacionesFuncionales.ToListAsync();
    }

    [HttpPost]
    public async Task<ActionResult<ClasificacionFuncional>> Post(ClasificacionFuncional clasificacion)
    {
        var currentYear = DateTime.Now.Year;
        if (clasificacion.AnioOperando < currentYear - 1 || clasificacion.AnioOperando > currentYear + 1)
        {
            return BadRequest("El campo 'AnioOperando' debe ser el año actual, el anterior o el siguiente.");
        }

        _context.ClasificacionesFuncionales.Add(clasificacion);
        await _context.SaveChangesAsync();
        return Ok(clasificacion);
    }

    [HttpGet("ultimo")]
    public async Task<ActionResult<ClasificacionFuncional>> GetUltimo()
    {
        var ultimo = await _context.ClasificacionesFuncionales
            .OrderByDescending(x => x.Id)
            .FirstOrDefaultAsync();

        if (ultimo == null) return NotFound();
        return Ok(ultimo);
    }

}
