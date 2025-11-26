using System.ComponentModel.DataAnnotations;

namespace PracticaFinal.DTOs
{
    public class ClienteDto
    {
        [Required]
        public long DT { get; set; } 
        [Required]
        public long Document { get; set; }
        [Required]
        public string First_Name { get; set; } = "";
        [Required]
        public string Last_Name { get; set; } = "";

        [Required]
        public long Whatsapp { get; set; }
        [Required]
        public string Address { get; set; } = "";
        [Required]
        public bool Status { get; set; } 
    }
}
