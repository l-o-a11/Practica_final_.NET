using System.ComponentModel.DataAnnotations;

namespace PracticaFinal.DTO
{
    public class ReservationDto
    {
        [Required]
        public required int ClienteId { get; set; }
        [Required]
        public required int ServiceId { get; set; }
        [Required]
        public required DateTime Date { get; set; }

		[Required]
		public required Boolean Status { get; set; }


	}
}

