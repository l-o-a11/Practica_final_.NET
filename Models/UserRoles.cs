namespace PracticaFinal.Model
{
    public class UserRoles
    {
        public int UserId { get; set; }
        public User User { get; set; } = null!;
        public int RoleId { get; set; }
        public Role Role { get; set; } = null!;

        //Agregar los atributos que requieran
        public DateTime AssignedAt { get; set; } = DateTime.UtcNow;
    }
}
