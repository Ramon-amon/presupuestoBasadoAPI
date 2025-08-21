using Microsoft.AspNetCore.Mvc;
using presupuestoBasadoAPI.Dto;
using presupuestoBasadoAPI.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace presupuestoBasadoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CoberturaController : ControllerBase
    {
        private readonly ICoberturaService _service;

        public CoberturaController(ICoberturaService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CoberturaDto>>> Get()
        {
            var list = await _service.GetAllAsync();
            return Ok(list);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CoberturaDto>> Get(int id)
        {
            var item = await _service.GetByIdAsync(id);
            if (item == null)
                return NotFound(new { message = $"Cobertura con ID {id} no encontrada" });

            return Ok(item);
        }

        [HttpGet("ultimo")]
        public async Task<ActionResult<CoberturaDto>> GetUltimo()
        {
            var ultimo = await _service.GetUltimoAsync();
            if (ultimo == null)
                return NotFound(new { message = "No hay registros en Cobertura" });

            return Ok(ultimo);
        }

        [HttpPost]
        public async Task<ActionResult<CoberturaDto>> Post([FromBody] CoberturaDto dto)
        {
            if (dto == null)
                return BadRequest(new { message = "El objeto dto es requerido" });

            var created = await _service.CreateAsync(dto);

            return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] CoberturaDto dto)
        {
            if (dto == null)
                return BadRequest(new { message = "El objeto dto es requerido" });

            var updated = await _service.UpdateAsync(id, dto);
            if (!updated)
                return NotFound(new { message = $"Cobertura con ID {id} no encontrada" });

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteAsync(id);
            if (!deleted)
                return NotFound(new { message = $"Cobertura con ID {id} no encontrada" });

            return NoContent();
        }
    }
}
