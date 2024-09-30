using Backend.Helpers.Interfaces;
using System.Security.Cryptography;

namespace Backend.Helpers
{
    public static class PasswordHasher
    {
        public const int HashSize = 32;
        public const int Iterations = 100_000;

        public static string Hash(string password, byte[] salt)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(password);

            if(salt == null || salt.Length == 0)
            {
                throw new ArgumentException("Salt cannot be null or empty", nameof(salt));
            }

            byte[] hash = Rfc2898DeriveBytes.Pbkdf2(password, salt, Iterations, HashAlgorithmName.SHA256, HashSize);

            return $"{Convert.ToHexString(hash)}-{Convert.ToHexString(salt)}";

        }
    }
    public sealed class PasswordHasherHelper
    {

        static public string Hash(string password, byte[] salt)
        {
            return PasswordHasher.Hash(password, salt);
        }

        //public bool VerifyPassword(string password, string hashpassword)
        //{
        //    string[] parts = hashpassword.Split('-');
        //    byte[] hash = Convert.FromHexString(parts[0]);
        //    byte[] salt = Convert.FromHexString(parts[1]);

        //    byte[] inputHash = Rfc2898DeriveBytes.Pbkdf2(password, salt, Iterations, Algorithm, HashSize);

        //    return CryptographicOperations.FixedTimeEquals(inputHash, hash);

        //}
    }
}
