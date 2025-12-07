namespace PracticaFinal.Models
{
    public class Servicios
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required decimal Price { get; set; }
        public required Boolean Status { get; set; }
        public ICollection<Reservation>? Reservations { get; set; }
    }
}
