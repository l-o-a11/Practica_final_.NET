namespace PracticaFinal.Models
{
    public class Reservation
    {
        public int Id { get; set; }

        public required int IdClient { get; set; }
        public required Cliente Cliente { get; set; }

        public int IdService { get; set; }
        public required Servicio Servico { get; set; }

        public required DateTime Date { get; set; }
        public required Boolean Status { get; set; }


    }
}
