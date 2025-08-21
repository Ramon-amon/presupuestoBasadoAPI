using presupuestoBasadoAPI.Dto;

namespace presupuestoBasadoAPI.Interfaces
{
    public interface IProgramaService
    {
        Task<IEnumerable<ProgramaDto>> GetAllAsync();
        Task<ProgramaDto?> GetByIdAsync(int id);
        Task<ProgramaDto> CreateAsync(CreateProgramaDto dto);
        Task<ProgramaDto?> UpdateAsync(int id, UpdateProgramaDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
