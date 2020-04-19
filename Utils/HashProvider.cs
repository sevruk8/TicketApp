using System;
using System.Security.Cryptography;
using System.Text;

namespace Utils
{
    public class HashProvider
    {
        private static readonly SHA512 hashProvider = new SHA512CryptoServiceProvider();

        public static string HashPassword(string password, string salt)
        {
            var bytesPasswordAndSalt = Encoding.UTF8.GetBytes(password + salt);
            var hashBytes = hashProvider.ComputeHash(bytesPasswordAndSalt);
            var s = new StringBuilder();
            foreach (var b in hashBytes)
            {
                s.Append(b.ToString("x2").ToLower());
            }
            return s.ToString();
        }
    }
}
