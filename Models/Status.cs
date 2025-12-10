namespace PracticaFinal.Models
{
	public class Status
	{
		public int Id { get; set; }
		public required string Descripcion { get; set; }

		public ICollection<Cliente>? Clients { get; set; }
		public ICollection<Service>? Service { get; set; }
		public ICollection<Reservation>? Reservations { get; set; }
	}
}