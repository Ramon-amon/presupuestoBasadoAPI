using Microsoft.EntityFrameworkCore;
using presupuestoBasadoAPI.Dto;
using presupuestoBasadoAPI.Interfaces;
using presupuestoBasadoAPI.Models;

namespace presupuestoBasadoAPI.Services
{
    public class JustificacionProgramaService : IJustificacionProgramaService
    {
        private readonly AppDbContext _context;

        public JustificacionProgramaService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<JustificacionPrograma>> ObtenerTodosAsync()
        {
            return await _context.JustificacionProgramas.ToListAsync();
        }

        public async Task<JustificacionPrograma?> ObtenerPorIdAsync(int id)
        {
            return await _context.JustificacionProgramas.FindAsync(id);
        }

        public async Task<JustificacionPrograma> CrearAsync(JustificacionProgramaDto dto)
        {
            var entidad = new JustificacionPrograma
            {
                RelevanciaSocial = dto.RelevanciaSocial,
                AlineacionPlaneacion = dto.AlineacionPlaneacion,
                ContribucionSolucion = dto.ContribucionSolucion
            };

            _context.JustificacionProgramas.Add(entidad);
            await _context.SaveChangesAsync();

            return entidad;
        }
    }

}
