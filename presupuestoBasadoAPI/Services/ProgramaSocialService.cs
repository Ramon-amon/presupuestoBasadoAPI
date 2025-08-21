using Microsoft.EntityFrameworkCore;
using presupuestoBasadoAPI.Data;
using presupuestoBasadoAPI.Dto;
using presupuestoBasadoAPI.Interfaces;
using presupuestoBasadoAPI.Models;

namespace presupuestoBasadoAPI.Services
{
    public class ProgramaSocialService : IProgramaSocialService
    {
        private readonly AppDbContext _context;

        public ProgramaSocialService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ProgramaSocialDto> CrearAsync(ProgramaSocialDto dto)
        {
            var entity = new ProgramaSocial
            {
                EsProgramaSocial = dto.EsProgramaSocial,
                Categorias = dto.Categorias.Select(c => new ProgramaSocialCategoria
                {
                    Nombre = c.Nombre,
                    Tipo = c.Tipo
                }).ToList()
            };

            _context.ProgramaSocial.Add(entity);
            await _context.SaveChangesAsync();

            return dto;
        }

        public async Task<ProgramaSocialDto?> ObtenerUltimoAsync()
        {
            var entity = await _context.ProgramaSocial
                .Include(p => p.Categorias)
                .OrderByDescending(p => p.Id)
                .FirstOrDefaultAsync();

            if (entity == null) return null;

            return new ProgramaSocialDto
            {
                EsProgramaSocial = entity.EsProgramaSocial,
                Categorias = entity.Categorias
                    .Select(c => new CategoriaDto
                    {
                        Nombre = c.Nombre,
                        Tipo = c.Tipo
                    }).ToList()
            };
        }
    }
}
