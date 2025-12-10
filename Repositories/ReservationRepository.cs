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

		public async Task<IEnumerable<Reservation>> GetAll() =>
                await _context.Reservations.ToListAsync();
        

        public async Task<Reservation?> GetById(int id) =>
		    	await _context.Reservations.FindAsync(id);


		public async Task<Reservation> Add(Reservation reservation)
        {
            _context.Reservations.Add(reservation);
            await _context.SaveChangesAsync();
            return reservation;
        }

		public async Task<Reservation?> Update(int id, Reservation reservation)
		{
			var existing = await _context.Reservations.FirstOrDefaultAsync(r => r.Id == id);
			if (existing == null) return null;
			existing.ClienteId = reservation.ClienteId;
			existing.ServiceId = reservation.ServiceId;
			existing.Date = reservation.Date;
			existing.StatusId = reservation.StatusId;
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

        public async Task<IEnumerable<Reservation>> GetByClient(int clientId) =>
				await _context.Reservations.ToListAsync();
                
		

	}
}
