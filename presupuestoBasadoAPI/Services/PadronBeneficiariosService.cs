﻿using Microsoft.EntityFrameworkCore;
using presupuestoBasadoAPI.Data;
using presupuestoBasadoAPI.Dto;
using presupuestoBasadoAPI.Interfaces;
using presupuestoBasadoAPI.Models;

namespace presupuestoBasadoAPI.Services
{
    public class PadronBeneficiariosService : IPadronBeneficiariosService
    {
        private readonly AppDbContext _context;

        public PadronBeneficiariosService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<PadronBeneficiariosDto> CrearAsync(PadronBeneficiariosDto dto)
        {
            var entidad = new PadronBeneficiarios
            {
                TienePadron = dto.TienePadron,
                ArchivoAdjunto = dto.ArchivoAdjunto,
                LigaInternet = dto.LigaInternet
            };

            _context.PadronBeneficiarios.Add(entidad);
            await _context.SaveChangesAsync();

            return dto;
        }

        public async Task<PadronBeneficiariosDto?> ObtenerUltimoAsync()
        {
            var entidad = await _context.PadronBeneficiarios
                .OrderByDescending(x => x.Id)
                .FirstOrDefaultAsync();

            if (entidad == null) return null;

            return new PadronBeneficiariosDto
            {
                TienePadron = entidad.TienePadron,
                ArchivoAdjunto = entidad.ArchivoAdjunto,
                LigaInternet = entidad.LigaInternet
            };
        }
    }
}
