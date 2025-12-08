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

        public async Task<IEnumerable<Service>> GetAll() =>
            await _context.Services.ToListAsync();

        public async Task<Service?> GetById(int id) =>
            await _context.Services.FindAsync(id);

        public async Task<Service> Add(Service service)
        {
            _context.Services.Add(service);
            await _context.SaveChangesAsync();
            return service;
        }

        public async Task<Service?> Update(int id, Service service)
        {
            var existing = await _context.Services.FindAsync(id);
            if (existing == null) return null;
            existing.Name = service.Name;
            existing.Price = service.Price;
            existing.Status = service.Status;

            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> Delete(int id)
        {
            var existing = await _context.Services.FindAsync(id);
            if (existing == null) return false;

            _context.Services.Remove(existing);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}