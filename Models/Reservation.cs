namespace PracticaFinal.Models
{
    public class Reservation
    {
        public int Id { get; set; }

        public required int IdClient { get; set; } = 0; 
        public Cliente? Cliente { get; set; }

        public required int IdService { get; set; } = 0;
        public Servicio? Servico { get; set; } 

        public required DateTime Date { get; set; }
        public required Boolean Status { get; set; }


    }
}
