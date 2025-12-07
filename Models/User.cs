namespace PracticaFinal.Model
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = "";
        public string PasswordHash { get; set; } = "";
        public string Role { get; set; } = "";

        //de muchos a muchos
        public ICollection<UserRoles> userRols { get; set; } = new List<UserRoles>();
    }
}
