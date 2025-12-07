namespace PracticaFinal.Models
{
    public class Servicios
    {
        public int Id { get; set; }
        public required string Nombre { get; set; }
        public decimal Precio { get; set; }
        public required string Status { get; set; }
        public ICollection<Reservation>? Reservations { get; set; }
    }
}
