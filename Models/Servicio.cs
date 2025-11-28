namespace PracticaFinal.Models
{
    public class Servicio
    {
        public int Id { get; set; }
        public required string Nombre { get; set; }
        public  required decimal Precio { get; set; }
        public required string Status { get; set; }
        //public ICollection<Reservation> Reservations { get; set; }

        public Reservation? Reservations { get; set; }
    }
}
