﻿using presupuestoBasadoAPI.Data;
using presupuestoBasadoAPI.Dto;
using presupuestoBasadoAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace presupuestoBasadoAPI.Services
{
    public class CoberturaService : ICoberturaService
    {
        private readonly AppDbContext _context;

        public CoberturaService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CoberturaDto>> GetAllAsync()
        {
            return await _context.Coberturas
                .Select(c => new CoberturaDto
                {
                    Id = c.Id,
                    IdentificacionCaracterizacionPoblacionPotencial = c.IdentificacionCaracterizacionPoblacionPotencial,
                    IdentificacionCaracterizacionPoblacionObjetivo = c.IdentificacionCaracterizacionPoblacionObjetivo,
                    UnidadMedida = c.UnidadMedida,
                    CuantificacionPoblacionPotencial = c.CuantificacionPoblacionPotencial,
                    CuantificacionPoblacionObjetivo = c.CuantificacionPoblacionObjetivo,
                    CuantificacionPoblacionAtendidaAnterior = c.CuantificacionPoblacionAtendidaAnterior,
                    FrecuenciaActualizacion = c.FrecuenciaActualizacion,
                    ProcesoIdentificacionPoblacionPotencial = c.ProcesoIdentificacionPoblacionPotencial,
                    ProcesoIdentificacionPoblacionObjetivo = c.ProcesoIdentificacionPoblacionObjetivo
                })
                .ToListAsync();
        }

        public async Task<CoberturaDto> GetByIdAsync(int id)
        {
            var c = await _context.Coberturas.FindAsync(id);
            if (c == null) return null;

            return new CoberturaDto
            {
                Id = c.Id,
                IdentificacionCaracterizacionPoblacionPotencial = c.IdentificacionCaracterizacionPoblacionPotencial,
                IdentificacionCaracterizacionPoblacionObjetivo = c.IdentificacionCaracterizacionPoblacionObjetivo,
                UnidadMedida = c.UnidadMedida,
                CuantificacionPoblacionPotencial = c.CuantificacionPoblacionPotencial,
                CuantificacionPoblacionObjetivo = c.CuantificacionPoblacionObjetivo,
                CuantificacionPoblacionAtendidaAnterior = c.CuantificacionPoblacionAtendidaAnterior,
                FrecuenciaActualizacion = c.FrecuenciaActualizacion,
                ProcesoIdentificacionPoblacionPotencial = c.ProcesoIdentificacionPoblacionPotencial,
                ProcesoIdentificacionPoblacionObjetivo = c.ProcesoIdentificacionPoblacionObjetivo
            };
        }

        public async Task<CoberturaDto> CreateAsync(CoberturaDto dto)
        {
            var c = new Cobertura
            {
                IdentificacionCaracterizacionPoblacionPotencial = dto.IdentificacionCaracterizacionPoblacionPotencial,
                IdentificacionCaracterizacionPoblacionObjetivo = dto.IdentificacionCaracterizacionPoblacionObjetivo,
                UnidadMedida = dto.UnidadMedida,
                CuantificacionPoblacionPotencial = dto.CuantificacionPoblacionPotencial,
                CuantificacionPoblacionObjetivo = dto.CuantificacionPoblacionObjetivo,
                CuantificacionPoblacionAtendidaAnterior = dto.CuantificacionPoblacionAtendidaAnterior,
                FrecuenciaActualizacion = dto.FrecuenciaActualizacion,
                ProcesoIdentificacionPoblacionPotencial = dto.ProcesoIdentificacionPoblacionPotencial,
                ProcesoIdentificacionPoblacionObjetivo = dto.ProcesoIdentificacionPoblacionObjetivo
            };

            _context.Coberturas.Add(c);
            await _context.SaveChangesAsync();

            dto.Id = c.Id;
            return dto;
        }

        public async Task<bool> UpdateAsync(int id, CoberturaDto dto)
        {
            var c = await _context.Coberturas.FindAsync(id);
            if (c == null) return false;

            c.IdentificacionCaracterizacionPoblacionPotencial = dto.IdentificacionCaracterizacionPoblacionPotencial;
            c.IdentificacionCaracterizacionPoblacionObjetivo = dto.IdentificacionCaracterizacionPoblacionObjetivo;
            c.UnidadMedida = dto.UnidadMedida;
            c.CuantificacionPoblacionPotencial = dto.CuantificacionPoblacionPotencial;
            c.CuantificacionPoblacionObjetivo = dto.CuantificacionPoblacionObjetivo;
            c.CuantificacionPoblacionAtendidaAnterior = dto.CuantificacionPoblacionAtendidaAnterior;
            c.FrecuenciaActualizacion = dto.FrecuenciaActualizacion;
            c.ProcesoIdentificacionPoblacionPotencial = dto.ProcesoIdentificacionPoblacionPotencial;
            c.ProcesoIdentificacionPoblacionObjetivo = dto.ProcesoIdentificacionPoblacionObjetivo;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var c = await _context.Coberturas.FindAsync(id);
            if (c == null) return false;

            _context.Coberturas.Remove(c);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<CoberturaDto> GetUltimoAsync()
        {
            var c = await _context.Coberturas
                .OrderByDescending(x => x.Id)
                .FirstOrDefaultAsync();

            if (c == null) return null;

            return new CoberturaDto
            {
                Id = c.Id,
                IdentificacionCaracterizacionPoblacionPotencial = c.IdentificacionCaracterizacionPoblacionPotencial,
                IdentificacionCaracterizacionPoblacionObjetivo = c.IdentificacionCaracterizacionPoblacionObjetivo,
                UnidadMedida = c.UnidadMedida,
                CuantificacionPoblacionPotencial = c.CuantificacionPoblacionPotencial,
                CuantificacionPoblacionObjetivo = c.CuantificacionPoblacionObjetivo,
                CuantificacionPoblacionAtendidaAnterior = c.CuantificacionPoblacionAtendidaAnterior,
                FrecuenciaActualizacion = c.FrecuenciaActualizacion,
                ProcesoIdentificacionPoblacionPotencial = c.ProcesoIdentificacionPoblacionPotencial,
                ProcesoIdentificacionPoblacionObjetivo = c.ProcesoIdentificacionPoblacionObjetivo
            };
        }
    }
}
