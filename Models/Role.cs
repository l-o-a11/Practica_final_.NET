namespace PracticaFinal.Model
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        //de muchos a muchos
        public ICollection<UserRoles> userRols { get; set; } = new List<UserRoles>();
    }
}
