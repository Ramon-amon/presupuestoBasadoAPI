﻿using Microsoft.EntityFrameworkCore;
using presupuestoBasadoAPI.Dto;
using presupuestoBasadoAPI.Interfaces;
using presupuestoBasadoAPI.Models;

namespace presupuestoBasadoAPI.Services
{
    public class ProgramaService : IProgramaService
    {
        private readonly AppDbContext _context;

        public ProgramaService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProgramaDto>> GetAllAsync()
        {
            return await _context.Programas
                .Select(p => new ProgramaDto
                {
                    Id = p.Id,
                    Clave = p.Clave,
                    Nombre = p.Nombre,
                    ObjetivoGeneral = p.ObjetivoGeneral,
                    UnidadResponsable = p.UnidadResponsable,
                    UnidadesIntegrantes = p.UnidadesIntegrantes
                }).ToListAsync();
        }

        public async Task<ProgramaDto?> GetByIdAsync(int id)
        {
            var programa = await _context.Programas.FindAsync(id);
            if (programa == null) return null;

            return new ProgramaDto
            {
                Id = programa.Id,
                Clave = programa.Clave,
                Nombre = programa.Nombre,
                ObjetivoGeneral = programa.ObjetivoGeneral,
                UnidadResponsable = programa.UnidadResponsable,
                UnidadesIntegrantes = programa.UnidadesIntegrantes
            };
        }

        public async Task<ProgramaDto> CreateAsync(CreateProgramaDto dto)
        {
            var programa = new ProgramaPresupuestario
            {
                Clave = dto.Clave,
                Nombre = dto.Nombre,
                ObjetivoGeneral = dto.ObjetivoGeneral,
                UnidadResponsable = dto.UnidadResponsable,
                UnidadesIntegrantes = dto.UnidadesIntegrantes
            };

            _context.Programas.Add(programa);
            await _context.SaveChangesAsync();

            return new ProgramaDto
            {
                Id = programa.Id,
                Clave = programa.Clave,
                Nombre = programa.Nombre,
                ObjetivoGeneral = programa.ObjetivoGeneral,
                UnidadResponsable = programa.UnidadResponsable,
                UnidadesIntegrantes = programa.UnidadesIntegrantes
            };
        }

        public async Task<ProgramaDto?> UpdateAsync(int id, UpdateProgramaDto dto)
        {
            var programa = await _context.Programas.FindAsync(id);
            if (programa == null) return null;

            programa.Clave = dto.Clave;
            programa.Nombre = dto.Nombre;
            programa.ObjetivoGeneral = dto.ObjetivoGeneral;
            programa.UnidadResponsable = dto.UnidadResponsable;
            programa.UnidadesIntegrantes = dto.UnidadesIntegrantes;

            await _context.SaveChangesAsync();

            return new ProgramaDto
            {
                Id = programa.Id,
                Clave = programa.Clave,
                Nombre = programa.Nombre,
                ObjetivoGeneral = programa.ObjetivoGeneral,
                UnidadResponsable = programa.UnidadResponsable,
                UnidadesIntegrantes = programa.UnidadesIntegrantes
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var programa = await _context.Programas.FindAsync(id);
            if (programa == null) return false;

            _context.Programas.Remove(programa);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
