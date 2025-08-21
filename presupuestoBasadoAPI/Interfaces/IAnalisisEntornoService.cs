using presupuestoBasadoAPI.Dto;
using presupuestoBasadoAPI.Models;

namespace presupuestoBasadoAPI.Interfaces
{
    public interface IAnalisisEntornoService
    {
        Task<AnalisisEntorno> CrearAsync(AnalisisEntornoDto dto);
        Task<List<AnalisisEntorno>> ObtenerTodosAsync();
        Task<AnalisisEntorno?> ObtenerPorIdAsync(int id);

    }

}
