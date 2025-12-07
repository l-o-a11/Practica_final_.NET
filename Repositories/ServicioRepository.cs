using Microsoft.EntityFrameworkCore;
using PracticaFinal.Data;
using PracticaFinal.Interfaces;
using PracticaFinal.Models;

namespace PracticaFinal.Repositories
{
    public class ServiceRepository : IServiceRepository
    {
        public readonly ApplicationDbContext _context;

        public ServiceRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Servicios>> GetAll() =>
            await _context.Services.ToListAsync();

        public async Task<Servicios?> GetById(int id) =>
            await _context.Services.FindAsync(id);

        public async Task<Servicios> Add(Servicios servicios)
        {
            _context.Servicios.Add(servicios);
            await _context.SaveChangesAsync();
            return servicios;
        }

        public async Task<Service?> Update(int id, Service servicios)
        {
            var existing = await _context.Services.FindAsync(id);
            if (existing == null) return null;
            existing.Name = servicios.Name;
            existing.Price = servicios.Price;
            existing.Status = servicios.Status;

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