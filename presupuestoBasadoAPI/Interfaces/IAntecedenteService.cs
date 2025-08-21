using presupuestoBasadoAPI.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace presupuestoBasadoAPI.Services
{
    public interface IAntecedenteService
    {
        Task<IEnumerable<AntecedenteDto>> GetAllAsync();
        Task<AntecedenteDto> GetByIdAsync(int id);
        Task<AntecedenteDto> CreateAsync(AntecedenteDto dto);
        Task<bool> UpdateAsync(int id, AntecedenteDto dto);
        Task<bool> DeleteAsync(int id);
        Task<AntecedenteDto> GetUltimoAsync();

    }
}
