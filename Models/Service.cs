namespace PracticaFinal.Models
{
    public class Service
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required decimal Price { get; set; }

		public required int StatusId { get; set; }
		public Status? Status { get; set; }

		public ICollection<Reservation>? Reservations { get; set; }
    }
}