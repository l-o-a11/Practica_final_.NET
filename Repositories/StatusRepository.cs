using Microsoft.EntityFrameworkCore;
using PracticaFinal.Data;
using PracticaFinal.Interfaces;
using PracticaFinal.Models;

namespace PracticaFinal.Repositories
{
    public class StatusRepository : IStatusRepository
    {
        public readonly ApplicationDbContext _context;

        public StatusRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Status>> GetAll() =>
            await _context.Status.ToListAsync();

        public async Task<Status?> GetById(int id) =>
            await _context.Status.FindAsync(id);

        public async Task<Status> Add(Status status)
        {
            _context.Status.Add(status);
            await _context.SaveChangesAsync();
            return status;
        }

        public async Task<Status?> Update(int id, Status status)
        {
            var existing = await _context.Status.FindAsync(id);
            if (existing == null) return null;
            existing.Descripcion = status.Descripcion;

            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> Delete(int id)
        {
            var existing = await _context.Status.FindAsync(id);
            if (existing == null) return false;

            _context.Status.Remove(existing);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}