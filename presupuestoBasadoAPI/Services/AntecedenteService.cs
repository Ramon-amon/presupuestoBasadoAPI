using presupuestoBasadoAPI.Data;
using presupuestoBasadoAPI.Dto;
using presupuestoBasadoAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace presupuestoBasadoAPI.Services
{
    public class AntecedenteService : IAntecedenteService
    {
        private readonly AppDbContext _context;

        public AntecedenteService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AntecedenteDto>> GetAllAsync()
        {
            return await _context.Antecedentes
                .Select(a => new AntecedenteDto
                {
                    Id = a.Id,
                    DescripcionPrograma = a.DescripcionPrograma,
                    ContextoHistoricoNormativo = a.ContextoHistoricoNormativo,
                    ProblematicaOrigen = a.ProblematicaOrigen,
                    ExperienciasPrevias = a.ExperienciasPrevias
                })
                .ToListAsync();
        }

        public async Task<AntecedenteDto> GetByIdAsync(int id)
        {
            var a = await _context.Antecedentes.FindAsync(id);
            if (a == null) return null;

            return new AntecedenteDto
            {
                Id = a.Id,
                DescripcionPrograma = a.DescripcionPrograma,
                ContextoHistoricoNormativo = a.ContextoHistoricoNormativo,
                ProblematicaOrigen = a.ProblematicaOrigen,
                ExperienciasPrevias = a.ExperienciasPrevias
            };
        }

        public async Task<AntecedenteDto> CreateAsync(AntecedenteDto dto)
        {
            var a = new Antecedente
            {
                DescripcionPrograma = dto.DescripcionPrograma,
                ContextoHistoricoNormativo = dto.ContextoHistoricoNormativo,
                ProblematicaOrigen = dto.ProblematicaOrigen,
                ExperienciasPrevias = dto.ExperienciasPrevias
            };

            _context.Antecedentes.Add(a);
            await _context.SaveChangesAsync();

            dto.Id = a.Id;
            return dto;
        }

        public async Task<bool> UpdateAsync(int id, AntecedenteDto dto)
        {
            var a = await _context.Antecedentes.FindAsync(id);
            if (a == null) return false;

            a.DescripcionPrograma = dto.DescripcionPrograma;
            a.ContextoHistoricoNormativo = dto.ContextoHistoricoNormativo;
            a.ProblematicaOrigen = dto.ProblematicaOrigen;
            a.ExperienciasPrevias = dto.ExperienciasPrevias;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var a = await _context.Antecedentes.FindAsync(id);
            if (a == null) return false;

            _context.Antecedentes.Remove(a);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<AntecedenteDto> GetUltimoAsync()
        {
            var a = await _context.Antecedentes
                      .OrderByDescending(x => x.Id)
                      .FirstOrDefaultAsync();

            if (a == null) return null;

            return new AntecedenteDto
            {
                Id = a.Id,
                DescripcionPrograma = a.DescripcionPrograma,
                ContextoHistoricoNormativo = a.ContextoHistoricoNormativo,
                ProblematicaOrigen = a.ProblematicaOrigen,
                ExperienciasPrevias = a.ExperienciasPrevias
            };
        }

    }
}
