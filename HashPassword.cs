using System;
using System.Security.Cryptography;
using System.Text;

namespace LoginDBContext
{
    public class HashPassword
    {

        public string hashedPassword;

        public HashPassword(string password) { 
        
            hashedPassword = hash_password(password);
        
        }

        public string hash_password(string password)
        {

            SHA256 hash = SHA256.Create();
            var passwordBytes = Encoding.Default.GetBytes(password);
            var hashedPassword = hash.ComputeHash(passwordBytes);

            return Convert.ToHexString(hashedPassword);

        }

    }

}