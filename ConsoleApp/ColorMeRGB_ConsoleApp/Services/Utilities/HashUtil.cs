using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Text;

namespace Services.Utilities
{
    public static class HashUtil
    {
        public static string HashPassword(string password, int salt) 
        {
            byte[] byteword = Encoding.Unicode.GetBytes(password);
            SHA512 sha512 = SHA512.Create();
            for (int i = 0; i < salt; i++) 
            {
                byteword = sha512.ComputeHash(byteword);
            }

            StringBuilder result = new StringBuilder();
            foreach (byte b in byteword) 
            {
                result.Append(b.ToString("x2"));
            }
            return result.ToString();
        }

        public static bool CheckPassword(string password, int salt, string hashedPassword) 
        {
            string hash = HashPassword(password, salt);
            return hashedPassword.Equals(hash);
        }
    }
}
