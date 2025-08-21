using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using presupuestoBasadoAPI.Dto;
using presupuestoBasadoAPI.Interfaces;

namespace presupuestoBasadoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IdentificacionProblemaController : ControllerBase
    {
        private readonly IIdentificacionProblemaService _service;
        private readonly AppDbContext _context;

        public IdentificacionProblemaController(IIdentificacionProblemaService service, AppDbContext context)
        {
            _service = service;
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] IdentificacionProblemaDto dto)
        {
            var resultado = await _service.CrearAsync(dto);
            return Ok(resultado);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<IdentificacionProblemaDto>>> GetAll()
        {
            var lista = await _service.ObtenerTodosAsync();
            return Ok(lista);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IdentificacionProblemaDto>> GetById(int id)
        {
            var resultado = await _service.ObtenerPorIdAsync(id);
            if (resultado == null)
                return NotFound();
            return Ok(resultado);
        }

        [HttpGet("ultimo")]
        public async Task<ActionResult<IdentificacionProblemaDto>> ObtenerUltimo()
        {
            var ultimo = await _context.IdentificacionProblemas
                .OrderByDescending(p => p.Id)
                .FirstOrDefaultAsync();

            if (ultimo == null)
                return NotFound("No se encontró ningún registro.");

            return Ok(ultimo);
        }

    }

}
