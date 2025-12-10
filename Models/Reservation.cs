namespace PracticaFinal.Models
{
    public class Reservation
    {
        public int Id { get; set; }

        public required int ClienteId { get; set; } 
        public Cliente? Cliente { get; set; }

        public required int ServiceId { get; set; } 

        public Service? Servicio { get; set; } 

        public required DateTime Date { get; set; }

		public required int StatusId { get; set; }
		public Status? Status { get; set; }



	}
}
