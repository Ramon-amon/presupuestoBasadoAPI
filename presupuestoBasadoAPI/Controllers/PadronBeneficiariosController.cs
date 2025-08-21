using Microsoft.AspNetCore.Mvc;
using presupuestoBasadoAPI.Dto;
using presupuestoBasadoAPI.Interfaces;

namespace presupuestoBasadoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PadronBeneficiariosController : ControllerBase
    {
        private readonly IPadronBeneficiariosService _service;

        public PadronBeneficiariosController(IPadronBeneficiariosService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] PadronBeneficiariosDto dto)
        {
            var creado = await _service.CrearAsync(dto);
            return Ok(creado);
        }

        [HttpGet("ultimo")]
        public async Task<IActionResult> ObtenerUltimo()
        {
            var ultimo = await _service.ObtenerUltimoAsync();
            if (ultimo == null) return NotFound();
            return Ok(ultimo);
        }
    }
}
