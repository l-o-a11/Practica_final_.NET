using System.ComponentModel.DataAnnotations;

namespace PracticaFinal.DTOs
{
    public class UserRoleDto
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public int RoleId { get; set; }
    }
}
