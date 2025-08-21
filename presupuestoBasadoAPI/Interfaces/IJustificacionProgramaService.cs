using presupuestoBasadoAPI.Dto;
using presupuestoBasadoAPI.Models;

namespace presupuestoBasadoAPI.Interfaces
{
    public interface IJustificacionProgramaService
    {
        Task<JustificacionPrograma> CrearAsync(JustificacionProgramaDto dto);
        Task<List<JustificacionPrograma>> ObtenerTodosAsync();
        Task<JustificacionPrograma?> ObtenerPorIdAsync(int id);
    }

}
