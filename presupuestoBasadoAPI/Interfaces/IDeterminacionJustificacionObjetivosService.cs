using presupuestoBasadoAPI.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace presupuestoBasadoAPI.Services
{
    public interface IDeterminacionJustificacionObjetivosService
    {
        Task<IEnumerable<DeterminacionJustificacionObjetivosDto>> GetAllAsync();
        Task<DeterminacionJustificacionObjetivosDto> GetByIdAsync(int id);
        Task<DeterminacionJustificacionObjetivosDto> CreateAsync(DeterminacionJustificacionObjetivosDto dto);
        Task<bool> UpdateAsync(int id, DeterminacionJustificacionObjetivosDto dto);
        Task<bool> DeleteAsync(int id);
        Task<DeterminacionJustificacionObjetivosDto> GetUltimoAsync();
    }
}
