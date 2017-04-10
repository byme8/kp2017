using System.Security.Cryptography;
using System.Text;

namespace kp.Business.Helpers
{
    public static class HashHelper
    {
        public static string GetHash(string password)
        {
            using (var sha = SHA256.Create())
            {
                var passwordTextBytes = Encoding.UTF8.GetBytes(password);
                var hash = sha.ComputeHash(passwordTextBytes);
                var hashString = Encoding.ASCII.GetString(hash);
                return hashString;
            }
        }
    }
}