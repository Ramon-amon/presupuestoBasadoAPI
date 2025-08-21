using presupuestoBasadoAPI.Dto;
using presupuestoBasadoAPI.Models;

namespace presupuestoBasadoAPI.Interfaces
{
    public interface IPoblacionObjetivoService
    {
        Task<PoblacionObjetivo> CrearAsync(PoblacionObjetivoDto dto);
        Task<List<PoblacionObjetivo>> ObtenerTodosAsync();
        Task<PoblacionObjetivo?> ObtenerPorIdAsync(int id);
    }

}
