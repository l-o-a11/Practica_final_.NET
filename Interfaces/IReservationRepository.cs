using PracticaFinal.Models;

namespace PracticaFinal.Interfaces
{
    public interface IReservationRepository
    {

            Task<IEnumerable<Reservation>> GetAll();
            Task<Reservation?> GetById(int id);
            Task<Reservation> Add(Reservation Reservations);
            Task<Reservation?> Update(int id, Reservation Reservations);
            Task<bool> Delete(int id);
		    //Task<IEnumerable<Reservation>> GetByClient(int clientId);


	}
}
