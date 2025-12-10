namespace PracticaFinal.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public required string DT { get; set; } = "";
        public long Document { get; set; }
        public string First_Name { get; set; } = "";
        public string Last_Name { get; set; } = "";
        public long Whatsapp { get; set; }
        public string Address { get; set; } = "";

		public required int StatusId { get; set; }
		public Status? Status { get; set; }


		public ICollection<Reservation>? Reservations { get; set; }
    }
}
