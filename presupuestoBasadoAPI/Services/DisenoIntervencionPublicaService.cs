using Microsoft.EntityFrameworkCore;
using presupuestoBasadoAPI.Data;
using presupuestoBasadoAPI.Dto;
using presupuestoBasadoAPI.DTOs;
using presupuestoBasadoAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace presupuestoBasadoAPI.Services
{
    public class DisenoIntervencionPublicaService : IDisenoIntervencionPublicaService
    {
        private readonly AppDbContext _context;

        public DisenoIntervencionPublicaService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DisenoIntervencionPublicaDto>> GetAllAsync()
        {
            return await _context.DisenoIntervencionPublicas
                .Include(d => d.Componentes)
                    .ThenInclude(c => c.Acciones)
                .Include(d => d.Componentes)
                    .ThenInclude(c => c.Resultados)
                .Select(d => new DisenoIntervencionPublicaDto
                {
                    Id = d.Id,
                    EtapasIntervencion = d.EtapasIntervencion,
                    EscenariosFuturosEsperar = d.EscenariosFuturosEsperar,
                    Componentes = d.Componentes.Select(c => new ComponenteDto
                    {
                        Id = c.Id,
                        Nombre = c.Nombre,
                        Acciones = c.Acciones.Select(a => a.Descripcion).ToList(),
                        Resultados = c.Resultados.Select(r => r.Descripcion).ToList()
                    }).ToList()
                })
                .ToListAsync();
        }

        public async Task<DisenoIntervencionPublicaDto> GetByIdAsync(int id)
        {
            var d = await _context.DisenoIntervencionPublicas
                .Include(x => x.Componentes)
                    .ThenInclude(c => c.Acciones)
                .Include(x => x.Componentes)
                    .ThenInclude(c => c.Resultados)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (d == null) return null;

            return new DisenoIntervencionPublicaDto
            {
                Id = d.Id,
                EtapasIntervencion = d.EtapasIntervencion,
                EscenariosFuturosEsperar = d.EscenariosFuturosEsperar,
                Componentes = d.Componentes.Select(c => new ComponenteDto
                {
                    Id = c.Id,
                    Nombre = c.Nombre,
                    Acciones = c.Acciones.Select(a => a.Descripcion).ToList(),
                    Resultados = c.Resultados.Select(r => r.Descripcion).ToList()
                }).ToList()
            };
        }

        public async Task<DisenoIntervencionPublicaDto> CreateAsync(DisenoIntervencionPublicaDto dto)
        {
            var d = new DisenoIntervencionPublica
            {
                EtapasIntervencion = dto.EtapasIntervencion,
                EscenariosFuturosEsperar = dto.EscenariosFuturosEsperar,
                Componentes = dto.Componentes.Select(c => new Componente
                {
                    Nombre = c.Nombre,
                    Acciones = c.Acciones.Select(a => new Accion { Descripcion = a }).ToList(),
                    Resultados = c.Resultados.Select(r => new Resultado { Descripcion = r }).ToList()
                }).ToList()
            };

            _context.DisenoIntervencionPublicas.Add(d);
            await _context.SaveChangesAsync();

            dto.Id = d.Id;
            return dto;
        }

        public async Task<bool> UpdateAsync(int id, DisenoIntervencionPublicaDto dto)
        {
            var d = await _context.DisenoIntervencionPublicas
                .Include(x => x.Componentes)
                    .ThenInclude(c => c.Acciones)
                .Include(x => x.Componentes)
                    .ThenInclude(c => c.Resultados)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (d == null) return false;

            d.EtapasIntervencion = dto.EtapasIntervencion;
            d.EscenariosFuturosEsperar = dto.EscenariosFuturosEsperar;

            // Eliminar hijos existentes para reemplazar por el nuevo grafo
            var accionesExistentes = d.Componentes.SelectMany(c => c.Acciones).ToList();
            var resultadosExistentes = d.Componentes.SelectMany(c => c.Resultados).ToList();
            _context.Acciones.RemoveRange(accionesExistentes);
            _context.Resultados.RemoveRange(resultadosExistentes);
            _context.Componentes.RemoveRange(d.Componentes);
            await _context.SaveChangesAsync();

            // Agregar nueva colección
            d.Componentes = dto.Componentes.Select(c => new Componente
            {
                Nombre = c.Nombre,
                Acciones = c.Acciones.Select(a => new Accion { Descripcion = a }).ToList(),
                Resultados = c.Resultados.Select(r => new Resultado { Descripcion = r }).ToList()
            }).ToList();

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var d = await _context.DisenoIntervencionPublicas
                .Include(x => x.Componentes)
                    .ThenInclude(c => c.Acciones)
                .Include(x => x.Componentes)
                    .ThenInclude(c => c.Resultados)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (d == null) return false;

            // Asegurar borrado en cascada de hijos
            _context.DisenoIntervencionPublicas.Remove(d);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<DisenoIntervencionPublicaDto> GetUltimoAsync()
        {
            var d = await _context.DisenoIntervencionPublicas
                .Include(x => x.Componentes)
                    .ThenInclude(c => c.Acciones)
                .Include(x => x.Componentes)
                    .ThenInclude(c => c.Resultados)
                .OrderByDescending(x => x.Id)
                .FirstOrDefaultAsync();

            if (d == null) return null;

            return new DisenoIntervencionPublicaDto
            {
                Id = d.Id,
                EtapasIntervencion = d.EtapasIntervencion,
                EscenariosFuturosEsperar = d.EscenariosFuturosEsperar,
                Componentes = d.Componentes.Select(c => new ComponenteDto
                {
                    Id = c.Id,
                    Nombre = c.Nombre,
                    Acciones = c.Acciones.Select(a => a.Descripcion).ToList(),
                    Resultados = c.Resultados.Select(r => r.Descripcion).ToList()
                }).ToList()
            };
        }
    }
}
