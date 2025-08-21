using presupuestoBasadoAPI.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace presupuestoBasadoAPI.Services
{
    public interface IIdentificacionDescripcionProblemaService
    {
        Task<IEnumerable<IdentificacionDescripcionProblemaDto>> GetAllAsync();
        Task<IdentificacionDescripcionProblemaDto> GetByIdAsync(int id);
        Task<IdentificacionDescripcionProblemaDto> CreateAsync(IdentificacionDescripcionProblemaDto dto);
        Task<bool> UpdateAsync(int id, IdentificacionDescripcionProblemaDto dto);
        Task<bool> DeleteAsync(int id);
        Task<IdentificacionDescripcionProblemaDto> GetUltimoAsync();
    }
}
