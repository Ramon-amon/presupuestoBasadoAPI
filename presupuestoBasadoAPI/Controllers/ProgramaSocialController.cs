using Microsoft.AspNetCore.Mvc;
using presupuestoBasadoAPI.Dto;
using presupuestoBasadoAPI.Interfaces;

namespace presupuestoBasadoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProgramaSocialController : ControllerBase
    {
        private readonly IProgramaSocialService _service;

        public ProgramaSocialController(IProgramaSocialService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] ProgramaSocialDto dto)
        {
            var creado = await _service.CrearAsync(dto);
            return Ok(creado);
        }

        [HttpGet("ultimo")]
        public async Task<IActionResult> ObtenerUltimo()
        {
            var data = await _service.ObtenerUltimoAsync();
            if (data == null) return NotFound();
            return Ok(data);
        }
    }
}
