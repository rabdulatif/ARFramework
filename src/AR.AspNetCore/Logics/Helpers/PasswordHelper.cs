using System.Security.Cryptography;

namespace AR.AspNetCore
{
    public class PasswordHelper
    {
        /// <summary>
        /// 
        /// </summary>
        private const int SALT_SIZE = 32; // size in bytes

        /// <summary>
        /// 
        /// </summary>
        private const int HASH_SIZE = 64; // size in bytes

        /// <summary>
        /// 
        /// </summary>
        private const int ITERATIONS = 1000; // number of pbkdf2 iterations

        /// <summary>
        /// 
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public static HashSalt GenerateHash(string password)
        {
            var saltBytes = new byte[SALT_SIZE];
            var provider = new RNGCryptoServiceProvider();
            provider.GetNonZeroBytes(saltBytes);
            var salt = Convert.ToBase64String(saltBytes);

            var rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, saltBytes, ITERATIONS);
            var hashPassword = Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(HASH_SIZE));

            var hashSalt = new HashSalt { Hash = hashPassword, Salt = salt };
            return hashSalt;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="enteredPassword"></param>
        /// <param name="storedHash"></param>
        /// <param name="storedSalt"></param>
        /// <returns></returns>
        public static bool VerifyPassword(string enteredPassword, string storedHash, string storedSalt)
        {
            if (enteredPassword == null)
                return false;

            var saltBytes = Convert.FromBase64String(storedSalt);
            var rfc2898DeriveBytes = new Rfc2898DeriveBytes(enteredPassword, saltBytes, ITERATIONS);
            return Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(HASH_SIZE)) == storedHash;
        }
    }
    
    public class HashSalt
    {
        public string Hash { get; set; }

        public string Salt { get; set; }
    }
}
