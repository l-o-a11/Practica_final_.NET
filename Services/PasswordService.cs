using System.Security.Cryptography;
using System.Text;

namespace PracticaFinal.Services
{
    public class PasswordService
    {
        public string Hash(string password)
        {
            var sha = SHA256.Create();
            var bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(bytes);
        }
        public bool Verify(string password, string hash)
        {
            return Hash(password) == hash;
        }
    }
}
