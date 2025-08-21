﻿using Microsoft.EntityFrameworkCore;
using presupuestoBasadoAPI.Dto;
using presupuestoBasadoAPI.Interfaces;
using presupuestoBasadoAPI.Models;

namespace presupuestoBasadoAPI.Services
{
    public class AnalisisEntornoService : IAnalisisEntornoService
    {
        private readonly AppDbContext _context;

        public AnalisisEntornoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<AnalisisEntorno>> ObtenerTodosAsync()
        {
            return await _context.AnalisisEntorno.ToListAsync();
        }

        public async Task<AnalisisEntorno?> ObtenerPorIdAsync(int id)
        {
            return await _context.AnalisisEntorno.FindAsync(id);
        }

        public async Task<AnalisisEntorno> CrearAsync(AnalisisEntornoDto dto)
        {
            var entidad = new AnalisisEntorno
            {
                FactoresInternos = dto.FactoresInternos,
                FactoresExternos = dto.FactoresExternos,
                RiesgosOportunidades = dto.RiesgosOportunidades,
                FechaCreacion = DateTime.Now
            };

            _context.AnalisisEntorno.Add(entidad);
            await _context.SaveChangesAsync();

            return entidad;
        }
    }
}
