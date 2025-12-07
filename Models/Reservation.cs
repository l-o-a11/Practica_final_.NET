namespace PracticaFinal.Models
{
    public class Reservation
    {
        public int Id { get; set; }

        public required int IdClient { get; set; } 
        public Cliente? Cliente { get; set; }

        public required int IdService { get; set; } 
        public Servicios? Servicio { get; set; } 

        public required DateTime Date { get; set; }
        public required Boolean Status { get; set; }


    }
}
