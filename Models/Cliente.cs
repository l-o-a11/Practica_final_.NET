namespace PracticaFinal.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public required long DT { get; set; }
        public long Document { get; set; }
        public string First_Name { get; set; } = "";
        public string Last_Name { get; set; } = "";
        public long Whatsapp { get; set; }
        public string Address { get; set; } = "";
        public bool Status { get; set; }

        //public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
        public Reservation? Reservation { get; set; }
    }
}
