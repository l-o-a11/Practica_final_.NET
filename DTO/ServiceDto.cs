using System.ComponentModel.DataAnnotations;

namespace PracticaFinal.DTO
{
    public class ServiceDto
    {
        [Required]
        public required string Name { get; set; }
        [Required]
        public required decimal Price { get; set; }
        [Required]
        public required Boolean Status { get; set; }
    }
}
