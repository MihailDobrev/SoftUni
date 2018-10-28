namespace SIS.Framework.Services
{
    using SIS.Framework.Services.Contracts;
    using System;
    using System.Security.Cryptography;
    using System.Text;

    public class HashService: IHashService
    {
        public string Hash(string stringToHash)
        {
            stringToHash = stringToHash + "%@mySalt!*&1642249";

            using (var sha256 = SHA256.Create())
            {
                // Send a sample text to hash.  
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(stringToHash));
                // Get the hashed string.  
                var hash = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
                // Print the string.   
                return hash;
            }
        }
    }
}
