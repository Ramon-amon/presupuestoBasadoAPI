using presupuestoBasadoAPI.Dto;

namespace presupuestoBasadoAPI.Interfaces
{
    public interface IArbolObjetivosService
    {
        Task<ArbolObjetivosDto?> GetUltimoAsync();
        Task<ArbolObjetivosDto> CrearAsync(ArbolObjetivosDto dto);
    }
}
