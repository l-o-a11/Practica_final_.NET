namespace PracticaFinal.Models
{
    public class Reservation
    {
        public int Id { get; set; }

        public required int IdClient { get; set; } 
        public Cliente? Cliente { get; set; }

        public required int IdService { get; set; } 
<<<<<<< HEAD
        public Servicios? Servicio { get; set; } 
=======
        public Servicio? Servicio { get; set; } 
>>>>>>> d4c6a5f3be4d176cff768ad933d3c3d864261508

        public required DateTime Date { get; set; }
        public required Boolean Status { get; set; }


    }
}
