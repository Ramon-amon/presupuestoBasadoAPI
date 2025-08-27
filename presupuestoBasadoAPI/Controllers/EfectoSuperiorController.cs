using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using presupuestoBasadoAPI.Models;
using presupuestoBasadoAPI.Dto;

namespace presupuestoBasadoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EfectoSuperiorController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EfectoSuperiorController(AppDbContext context)
        {
            _context = context;
        }

        // POST api/EfectoSuperior
        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] EfectoSuperiorDto dto)
        {
            var nuevo = new EfectoSuperior
            {
                Descripcion = dto.Descripcion,
                FechaRegistro = DateTime.UtcNow
            };

            _context.EfectosSuperiores.Add(nuevo);
            await _context.SaveChangesAsync();

            return Ok(new { message = "✅ Efecto Superior guardado correctamente", nuevo.Id });
        }

        // GET api/EfectoSuperior/ultimo
        [HttpGet("ultimo")]
        public async Task<ActionResult<EfectoSuperior>> Ultimo()
        {
            var ultimo = await _context.EfectosSuperiores
                .OrderByDescending(e => e.FechaRegistro)
                .FirstOrDefaultAsync();

            if (ultimo == null) return NotFound("No hay registros de efecto superior.");

            return Ok(ultimo);
        }
    }
}
