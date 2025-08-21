using presupuestoBasadoAPI.Dto;
using presupuestoBasadoAPI.Models;

namespace presupuestoBasadoAPI.Interfaces
{
    public interface IIdentificacionProblemaService
    {
        Task<IdentificacionProblema> CrearAsync(IdentificacionProblemaDto dto);
        Task<List<IdentificacionProblema>> ObtenerTodosAsync();
        Task<IdentificacionProblema?> ObtenerPorIdAsync(int id);
    }

}
