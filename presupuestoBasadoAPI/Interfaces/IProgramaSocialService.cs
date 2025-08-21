using presupuestoBasadoAPI.Dto;

namespace presupuestoBasadoAPI.Interfaces
{
    public interface IProgramaSocialService
    {
        Task<ProgramaSocialDto> CrearAsync(ProgramaSocialDto dto);
        Task<ProgramaSocialDto?> ObtenerUltimoAsync();
    }
}
