using presupuestoBasadoAPI.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace presupuestoBasadoAPI.Services
{
    public interface IDisenoIntervencionPublicaService
    {
        Task<IEnumerable<DisenoIntervencionPublicaDto>> GetAllAsync();
        Task<DisenoIntervencionPublicaDto> GetByIdAsync(int id);
        Task<DisenoIntervencionPublicaDto> CreateAsync(DisenoIntervencionPublicaDto dto);
        Task<bool> UpdateAsync(int id, DisenoIntervencionPublicaDto dto);
        Task<bool> DeleteAsync(int id);
        Task<DisenoIntervencionPublicaDto> GetUltimoAsync();
    }
}
