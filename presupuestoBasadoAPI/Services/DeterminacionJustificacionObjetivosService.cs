using presupuestoBasadoAPI.Data;
using presupuestoBasadoAPI.Dto;
using presupuestoBasadoAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace presupuestoBasadoAPI.Services
{
    public class DeterminacionJustificacionObjetivosService : IDeterminacionJustificacionObjetivosService
    {
        private readonly AppDbContext _context;

        public DeterminacionJustificacionObjetivosService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DeterminacionJustificacionObjetivosDto>> GetAllAsync()
        {
            return await _context.DeterminacionJustificacionObjetivo
                .Select(d => new DeterminacionJustificacionObjetivosDto
                {
                    Id = d.Id,
                    ObjetivosEspecificos = d.ObjetivosEspecificos,
                    RelacionOtrosProgramas = d.RelacionOtrosProgramas
                })
                .ToListAsync();
        }

        public async Task<DeterminacionJustificacionObjetivosDto> GetByIdAsync(int id)
        {
            var d = await _context.DeterminacionJustificacionObjetivo.FindAsync(id);
            if (d == null) return null;

            return new DeterminacionJustificacionObjetivosDto
            {
                Id = d.Id,
                ObjetivosEspecificos = d.ObjetivosEspecificos,
                RelacionOtrosProgramas = d.RelacionOtrosProgramas
            };
        }

        public async Task<DeterminacionJustificacionObjetivosDto> CreateAsync(DeterminacionJustificacionObjetivosDto dto)
        {
            var d = new DeterminacionJustificacionObjetivos
            {
                ObjetivosEspecificos = dto.ObjetivosEspecificos,
                RelacionOtrosProgramas = dto.RelacionOtrosProgramas
            };

            _context.DeterminacionJustificacionObjetivo.Add(d);
            await _context.SaveChangesAsync();

            dto.Id = d.Id;
            return dto;
        }

        public async Task<bool> UpdateAsync(int id, DeterminacionJustificacionObjetivosDto dto)
        {
            var d = await _context.DeterminacionJustificacionObjetivo.FindAsync(id);
            if (d == null) return false;

            d.ObjetivosEspecificos = dto.ObjetivosEspecificos;
            d.RelacionOtrosProgramas = dto.RelacionOtrosProgramas;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var d = await _context.DeterminacionJustificacionObjetivo.FindAsync(id);
            if (d == null) return false;

            _context.DeterminacionJustificacionObjetivo.Remove(d);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<DeterminacionJustificacionObjetivosDto> GetUltimoAsync()
        {
            var d = await _context.DeterminacionJustificacionObjetivo
                .OrderByDescending(x => x.Id)
                .FirstOrDefaultAsync();

            if (d == null) return null;

            return new DeterminacionJustificacionObjetivosDto
            {
                Id = d.Id,
                ObjetivosEspecificos = d.ObjetivosEspecificos,
                RelacionOtrosProgramas = d.RelacionOtrosProgramas
            };
        }
    }
}
