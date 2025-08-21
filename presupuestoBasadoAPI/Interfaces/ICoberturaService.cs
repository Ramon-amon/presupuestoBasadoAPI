using presupuestoBasadoAPI.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace presupuestoBasadoAPI.Services
{
    public interface ICoberturaService
    {
        Task<IEnumerable<CoberturaDto>> GetAllAsync();
        Task<CoberturaDto> GetByIdAsync(int id);
        Task<CoberturaDto> CreateAsync(CoberturaDto dto);
        Task<bool> UpdateAsync(int id, CoberturaDto dto);
        Task<bool> DeleteAsync(int id);
        Task<CoberturaDto> GetUltimoAsync();
    }
}
