using System;
using System.Security.Cryptography;

using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace SimCard.APP.Persistence
{
    public class PasswordHelper
    {
        public static string GetSalt()
        {
            byte[] salt = new byte[128 / 8];
            using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            return Convert.ToBase64String(salt);
        }

        public static string HashPassword(string password, string salt)
        {
            return Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: Convert.FromBase64String(salt),
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8
            ));
        }

        public static bool ValidatePassword(string passwordToValidate, string hashedPassword, string salt)
        {
            var password = HashPassword(passwordToValidate, salt);
            if (password.Equals(hashedPassword))
            {
                return true;
            }
            return false;
        }
    }
}
