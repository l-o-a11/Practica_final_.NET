using PracticaFinal.Inderfaces;
using PracticaFinal.Model;
using Microsoft.EntityFrameworkCore;
using PracticaFinal.Data;

namespace PracticaFinal.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<User> GetByUsernameAsync(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Username == username);
        }
        public async Task<User> RegisterAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }
        public async Task<UserRoles> AssignRoleAsync(int userId, int roleId)
        {
            var exist = await _context.UserRoles
                .AnyAsync(ur => ur.UserId == userId && ur.RoleId == roleId);

            if (exist)
            {
                // Si ya existe, devolver la relación existente (opcional)
                return await _context.UserRoles
                    .FirstAsync(ur => ur.UserId == userId && ur.RoleId == roleId);
            }

            var userRole = new UserRoles
            {
                UserId = userId,
                RoleId = roleId,
                AssignedAt = DateTime.UtcNow
            };

            _context.UserRoles.Add(userRole);
            await _context.SaveChangesAsync();

            // Cargar nav props si las necesitas en la respuesta
            await _context.Entry(userRole).Reference(ur => ur.User).LoadAsync();
            await _context.Entry(userRole).Reference(ur => ur.Role).LoadAsync();

            return userRole;
        }
    }
}