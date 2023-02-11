using Core.Models;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;

namespace Infrastructure.Services
{
    public class SecurityService
    {
        struct GlobalHashData
        {
            public static readonly int keySize = 64;
            public static readonly int iteration = 350000;
            public static readonly HashAlgorithmName hashAlgorithm = HashAlgorithmName.SHA512;
        }
        public static string HashPassword(string password, out byte[] salt)
        {
            salt = RandomNumberGenerator.GetBytes(GlobalHashData.keySize);
            var hash = Rfc2898DeriveBytes.Pbkdf2(
                Encoding.UTF8.GetBytes(password),
                salt,
                GlobalHashData.iteration,
                GlobalHashData.hashAlgorithm,
                GlobalHashData.keySize);

            return Convert.ToHexString(hash);
        }

        public static bool VerifyPassword(string attemptedPassword, Security usersSecuredData)
        {
            var hashToCompare = Rfc2898DeriveBytes.Pbkdf2(Encoding.UTF8.GetBytes(attemptedPassword), Convert.FromHexString(usersSecuredData.Salt), GlobalHashData.iteration, GlobalHashData.hashAlgorithm, GlobalHashData.keySize);
            return hashToCompare.SequenceEqual(Convert.FromHexString(usersSecuredData.HashedPassword));
        }
    }
}
