using Microsoft.AspNetCore.Mvc;
using presupuestoBasadoAPI.Interfaces;
using presupuestoBasadoAPI.Dto;

namespace presupuestoBasadoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArbolObjetivosController : ControllerBase
    {
        private readonly IArbolObjetivosService _service;

        public ArbolObjetivosController(IArbolObjetivosService service)
        {
            _service = service;
        }

        [HttpGet("ultimo")]
        public async Task<IActionResult> GetUltimo()
        {
            var result = await _service.GetUltimoAsync();
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] ArbolObjetivosDto dto)
        {
            var result = await _service.CrearAsync(dto);
            return Ok(result);
        }
    }
}
