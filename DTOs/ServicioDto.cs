using System.ComponentModel.DataAnnotations;

namespace PracticaFinal.DTO
{
    public class ServicioDto
    {
        [Required]
        public required string Nombre { get; set; }
        [Required]
        public required string Descripcion { get; set; }
        [Required]
        public required decimal Precio { get; set; }
    }
}
