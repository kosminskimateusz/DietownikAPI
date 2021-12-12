using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Dietownik.ApplicationServices.Components
{
    public class PasswordHasher : IPasswordHasher
    {
        readonly int _saltLength = 128 / 8;
        readonly int _hashLength = 256 / 8;
        public string Hash(string password)
        {

            // generate a 128-bit salt using a secure PRNG
            byte[] salt = new byte[_saltLength];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }


            // derive a 256-bit subkey (use HMACSHA1 with 10,000 iterations)
            byte[] hash = (KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: _hashLength));

            byte[] hashBytes = new byte[_saltLength + _hashLength];
            Array.Copy(salt, 0, hashBytes, 0, _saltLength);
            Array.Copy(hash, 0, hashBytes, _saltLength, _hashLength);

            string hashed = Convert.ToBase64String(hashBytes);
            return hashed;
        }

        public bool HashCheck(string passwordFromDatabase, string logginPassword)
        {
            bool passwordApproved = false;
            byte[] hashBytes = Convert.FromBase64String(passwordFromDatabase);
            byte[] salt = new byte[_saltLength];
            Array.Copy(hashBytes, 0, salt, 0, _saltLength);
            var hash = (KeyDerivation.Pbkdf2(
                password: logginPassword,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: _hashLength));

            for (int i = 0; i < _hashLength; i++)
            {
                if (hashBytes[i + _saltLength] == hash[i])
                    passwordApproved = true;
                else
                    passwordApproved = false;
            }
            return passwordApproved;
        }
    }
}
