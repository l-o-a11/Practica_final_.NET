using PracticaFinal.Model;

namespace PracticaFinal.Inderfaces
{
    public interface IUserRepository
    {
        Task<User> GetByUsernameAsync(string username);
        Task<User> RegisterAsync(User user);

    }
}