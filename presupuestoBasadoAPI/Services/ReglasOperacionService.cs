using Microsoft.EntityFrameworkCore;
using presupuestoBasadoAPI.Dto;
using presupuestoBasadoAPI.Interfaces;
using presupuestoBasadoAPI.Models;

namespace presupuestoBasadoAPI.Services
{
    public class ReglasOperacionService : IReglasOperacionService
    {
        private readonly AppDbContext _context;

        public ReglasOperacionService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ReglasOperacion> CrearAsync(ReglasOperacionDto dto)
        {
            var entidad = new ReglasOperacion
            {
                TieneReglasOperacion = dto.TieneReglasOperacion,
                ArchivoAdjunto = dto.ArchivoAdjunto,
                LigaInternet = dto.LigaInternet
            };

            _context.ReglasOperacion.Add(entidad);
            await _context.SaveChangesAsync();
            return entidad;
        }

        public async Task<ReglasOperacion?> ObtenerUltimoAsync()
        {
            return await _context.ReglasOperacion
                .OrderByDescending(r => r.Id)
                .FirstOrDefaultAsync();
        }
    }
}
