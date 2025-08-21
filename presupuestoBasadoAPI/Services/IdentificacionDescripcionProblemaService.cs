﻿using presupuestoBasadoAPI.Data;
using presupuestoBasadoAPI.Dto;
using presupuestoBasadoAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace presupuestoBasadoAPI.Services
{
    public class IdentificacionDescripcionProblemaService : IIdentificacionDescripcionProblemaService
    {
        private readonly AppDbContext _context;

        public IdentificacionDescripcionProblemaService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<IdentificacionDescripcionProblemaDto>> GetAllAsync()
        {
            return await _context.IdentificacionDescripcionProblemas
                .Select(p => new IdentificacionDescripcionProblemaDto
                {
                    Id = p.Id,
                    ProblemaCentral = p.ProblemaCentral,
                    Involucrados = p.Involucrados,
                    CausaBeneficiados = p.CausaBeneficiados,
                    CausaOpositores = p.CausaOpositores,
                    CausaEjecutores = p.CausaEjecutores,
                    CausaIndiferentes = p.CausaIndiferentes,
                    Efectos = p.Efectos,
                    Evolucion = p.Evolucion
                })
                .ToListAsync();
        }

        public async Task<IdentificacionDescripcionProblemaDto> GetByIdAsync(int id)
        {
            var p = await _context.IdentificacionDescripcionProblemas.FindAsync(id);
            if (p == null) return null;

            return new IdentificacionDescripcionProblemaDto
            {
                Id = p.Id,
                ProblemaCentral = p.ProblemaCentral,
                Involucrados = p.Involucrados,
                CausaBeneficiados = p.CausaBeneficiados,
                CausaOpositores = p.CausaOpositores,
                CausaEjecutores = p.CausaEjecutores,
                CausaIndiferentes = p.CausaIndiferentes,
                Efectos = p.Efectos,
                Evolucion = p.Evolucion
            };
        }

        public async Task<IdentificacionDescripcionProblemaDto> CreateAsync(IdentificacionDescripcionProblemaDto dto)
        {
            var p = new IdentificacionDescripcionProblema
            {
                ProblemaCentral = dto.ProblemaCentral,
                Involucrados = dto.Involucrados,
                CausaBeneficiados = dto.CausaBeneficiados,
                CausaOpositores = dto.CausaOpositores,
                CausaEjecutores = dto.CausaEjecutores,
                CausaIndiferentes = dto.CausaIndiferentes,
                Efectos = dto.Efectos,
                Evolucion = dto.Evolucion
            };

            _context.IdentificacionDescripcionProblemas.Add(p);
            await _context.SaveChangesAsync();

            dto.Id = p.Id;
            return dto;
        }

        public async Task<bool> UpdateAsync(int id, IdentificacionDescripcionProblemaDto dto)
        {
            var p = await _context.IdentificacionDescripcionProblemas.FindAsync(id);
            if (p == null) return false;

            p.ProblemaCentral = dto.ProblemaCentral;
            p.Involucrados = dto.Involucrados;
            p.CausaBeneficiados = p.CausaBeneficiados;
            p.CausaOpositores = p.CausaOpositores;
            p.CausaEjecutores = p.CausaEjecutores;
            p.CausaIndiferentes = p.CausaIndiferentes;
            p.Efectos = dto.Efectos;
            p.Evolucion = dto.Evolucion;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var p = await _context.IdentificacionDescripcionProblemas.FindAsync(id);
            if (p == null) return false;

            _context.IdentificacionDescripcionProblemas.Remove(p);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IdentificacionDescripcionProblemaDto> GetUltimoAsync()
        {
            var p = await _context.IdentificacionDescripcionProblemas
                .OrderByDescending(x => x.Id)
                .FirstOrDefaultAsync();

            if (p == null) return null;

            return new IdentificacionDescripcionProblemaDto
            {
                Id = p.Id,
                ProblemaCentral = p.ProblemaCentral,
                Involucrados = p.Involucrados,
                CausaBeneficiados = p.CausaBeneficiados,
                CausaOpositores = p.CausaOpositores,
                CausaEjecutores = p.CausaEjecutores,
                CausaIndiferentes = p.CausaIndiferentes,
                Efectos = p.Efectos,
                Evolucion = p.Evolucion
            };
        }
    }
}
