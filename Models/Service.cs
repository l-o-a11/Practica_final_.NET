namespace PracticaFinal.Models
{
    public class Service
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public  required decimal Price { get; set; }
        public required Boolean Status { get; set; }
    }
}
