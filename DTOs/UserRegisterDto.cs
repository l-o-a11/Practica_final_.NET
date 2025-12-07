
using System.ComponentModel.DataAnnotations;

namespace PracticaFinal.DTOs
{
    public class UserRegisterDto
    {
        [Required]
        public string Username { get; set; } = "";
        [Required]

        public string Password { get; set; } = "";
    }
}
