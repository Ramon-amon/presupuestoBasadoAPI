using Microsoft.AspNetCore.Mvc;
using presupuestoBasadoAPI.Dto;
using presupuestoBasadoAPI.Interfaces;
using presupuestoBasadoAPI.Models;

namespace presupuestoBasadoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReglasOperacionController : ControllerBase
    {
        private readonly IReglasOperacionService _service;

        public ReglasOperacionController(IReglasOperacionService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult<ReglasOperacion>> Crear(ReglasOperacionDto dto)
        {
            var nuevo = await _service.CrearAsync(dto);
            return Ok(nuevo);
        }

        [HttpGet("ultimo")]
        public async Task<ActionResult<ReglasOperacion?>> ObtenerUltimo()
        {
            var ultimo = await _service.ObtenerUltimoAsync();
            if (ultimo == null)
                return NotFound();
            return Ok(ultimo);
        }
    }
}
