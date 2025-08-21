using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using presupuestoBasadoAPI.Models;

namespace presupuestoBasadoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlineacionMunicipioController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AlineacionMunicipioController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AlineacionMunicipio>>> GetAll()
        {
            return await _context.AlineacionesMunicipio.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult> Crear(AlineacionMunicipio modelo)
        {
            _context.AlineacionesMunicipio.Add(modelo);
            await _context.SaveChangesAsync();
            return Ok(modelo);
        }

        [HttpGet("ultimo")]
        public async Task<ActionResult<AlineacionMunicipio>> GetUltimo()
        {
            var ultimo = await _context.AlineacionesMunicipio
                .OrderByDescending(x => x.Id)
                .FirstOrDefaultAsync();

            if (ultimo == null) return NotFound();
            return Ok(ultimo);
        }

    }

}
