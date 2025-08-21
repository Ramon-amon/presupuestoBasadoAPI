using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using presupuestoBasadoAPI.Dto;
using presupuestoBasadoAPI.Interfaces;
using presupuestoBasadoAPI.Models;

namespace presupuestoBasadoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PoblacionObjetivoController : ControllerBase
    {
        private readonly IPoblacionObjetivoService _service;
        private readonly AppDbContext _context;

        public PoblacionObjetivoController(IPoblacionObjetivoService service, AppDbContext context)
        {
            _service = service;
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PoblacionObjetivoDto dto)
        {
            var resultado = await _service.CrearAsync(dto);
            return Ok(resultado);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PoblacionObjetivo>>> GetAll()
        {
            var lista = await _service.ObtenerTodosAsync();
            return Ok(lista);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PoblacionObjetivo>> GetById(int id)
        {
            var resultado = await _service.ObtenerPorIdAsync(id);
            if (resultado == null)
                return NotFound();
            return Ok(resultado);
        }

        [HttpGet("ultimo")]
        public async Task<ActionResult<PoblacionObjetivoDto>> ObtenerUltimo()
        {
            var ultimo = await _context.PoblacionObjetivo
                .OrderByDescending(p => p.Id)
                .FirstOrDefaultAsync();

            if (ultimo == null)
                return NotFound("No se encontró ningún registro.");

            return Ok(ultimo);
        }

    }

}
