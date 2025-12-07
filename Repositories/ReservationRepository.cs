using Microsoft.EntityFrameworkCore;
using PracticaFinal.Data;
using PracticaFinal.Interfaces;
using PracticaFinal.Models;

namespace PracticaFinal.Repositories
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly ApplicationDbContext _context;

        public ReservationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Reservation>> GetAll()
        {
            return await _context.Reservations
                .AsNoTracking()
                .Include(r => r.Cliente)
                .Include(r => r.Servicio)
                .ToListAsync();
        }

        public async Task<Reservation?> GetById(int id)
        {
            return await _context.Reservations
                .AsNoTracking()
                .Include(r => r.Cliente)
                .Include(r => r.Servicio)
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<Reservation> Add(Reservation reservation)
        {
            _context.Reservations.Add(reservation);
            await _context.SaveChangesAsync();
            return reservation;
        }

        public async Task<Reservation?> Update(int id, Reservation reservation)
        {
            var existing = await _context.Reservations.FindAsync(id);

            if (existing == null)
                return null;

            _context.Entry(existing).CurrentValues.SetValues(reservation);

            await _context.SaveChangesAsync();
            return existing;
        }


        public async Task<bool> Delete(int id)
        {
            var reservation = await _context.Reservations.FindAsync(id);

            if (reservation == null)
                return false;

            _context.Reservations.Remove(reservation);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
