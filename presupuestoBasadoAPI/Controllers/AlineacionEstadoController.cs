using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using presupuestoBasadoAPI.Models;

namespace presupuestoBasadoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlineacionEstadoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AlineacionEstadoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AlineacionEstado>>> GetAll()
        {
            return await _context.AlineacionesEstado.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult> Crear(AlineacionEstado modelo)
        {
            _context.AlineacionesEstado.Add(modelo);
            await _context.SaveChangesAsync();
            return Ok(modelo);
        }

        [HttpGet("ultimo")]
        public async Task<ActionResult<AlineacionEstado>> GetUltimo()
        {
            var ultimo = await _context.AlineacionesEstado
                .OrderByDescending(x => x.Id)
                .FirstOrDefaultAsync();

            if (ultimo == null) return NotFound();
            return Ok(ultimo);
        }

    }

}
