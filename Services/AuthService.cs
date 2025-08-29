using System.Security.Cryptography;
using System.Text;
using SafeVault.Models;

namespace SafeVault.Services
{
    public class AuthService
    {
        public string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(bytes);
        }

        public bool ValidatePassword(string password, string hash)
        {
            return HashPassword(password) == hash;
        }
    }
}