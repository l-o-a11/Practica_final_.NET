using Microsoft.EntityFrameworkCore;
using PracticaFinal.Data;
using PracticaFinal.Interfaces;
using PracticaFinal.Models;

namespace PracticaFinal.Repositories
{
    public class ServicioRepository : ISevicioRepository
    {
        public readonly ApplicationDbContext _context;

        public ServicioRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Servicio>> GetAll() =>
            await _context.Servicios.ToListAsync();

        public async Task<Servicio?> GetById(int id) =>
            await _context.Servicios.FindAsync(id);

        public async Task<Servicio> Add(Servicio servicio)
        {
            _context.Servicios.Add(servicio);
            await _context.SaveChangesAsync();
            return servicio;
        }

        public async Task<Servicio?> Update(int id, Servicio servicio)
        {
            var existing = await _context.Servicios.FindAsync(id);
            if (existing == null) return null;
            existing.Nombre = servicio.Nombre;
            existing.Descripcion = servicio.Descripcion;

            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> Delete(int id)
        {
            var existing = await _context.Servicios.FindAsync(id);
            if (existing == null) return false;

            _context.Servicios.Remove(existing);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
