using Microsoft.EntityFrameworkCore;
using presupuestoBasadoAPI.Dto;
using presupuestoBasadoAPI.Interfaces;
using presupuestoBasadoAPI.Models;

namespace presupuestoBasadoAPI.Services
{
    public class IdentificacionProblemaService : IIdentificacionProblemaService
    {
        private readonly AppDbContext _context;

        public IdentificacionProblemaService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<IdentificacionProblema>> ObtenerTodosAsync()
        {
            return await _context.IdentificacionProblemas.ToListAsync();
        }

        public async Task<IdentificacionProblema?> ObtenerPorIdAsync(int id)
        {
            return await _context.IdentificacionProblemas.FindAsync(id);
        }

        public async Task<IdentificacionProblema> CrearAsync(IdentificacionProblemaDto dto)
        {
            var entidad = new IdentificacionProblema
            {
                DiagnosticoSituacionActual = dto.DiagnosticoSituacionActual,
                ProblemaCentral = dto.ProblemaCentral,
                EvidenciaProblema = dto.EvidenciaProblema
            };

            _context.IdentificacionProblemas.Add(entidad);
            await _context.SaveChangesAsync();

            return entidad;
        }
    }


}
