using presupuestoBasadoAPI.Dto;
using presupuestoBasadoAPI.Models;

namespace presupuestoBasadoAPI.Interfaces
{
    public interface IReglasOperacionService
    {
        Task<ReglasOperacion> CrearAsync(ReglasOperacionDto dto);
        Task<ReglasOperacion?> ObtenerUltimoAsync();
    }
}
