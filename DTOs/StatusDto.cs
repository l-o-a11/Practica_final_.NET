using System.ComponentModel.DataAnnotations;

namespace PracticaFinal.DTO
{
    public class StatusDto
    {
        [Required]
        public required string Descripcion { get; set; } = "";
       

    }
}