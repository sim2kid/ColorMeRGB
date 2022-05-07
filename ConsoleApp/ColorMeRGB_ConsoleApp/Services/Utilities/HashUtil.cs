using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Text;

// Written by Owen Ravelo

namespace Services.Utilities
{
    public static class HashUtil
    {
        private static readonly char[] chars = "abcdefghijklmnopqrstuvwxyz1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
        private static readonly Random random = new Random();

        public static string HashPassword(string password, string salt) 
        {
            byte[] byteword = Encoding.Unicode.GetBytes(password + salt);
            SHA512 sha512 = SHA512.Create();
            byteword = sha512.ComputeHash(byteword);

            StringBuilder result = new StringBuilder();
            foreach (byte b in byteword) 
            {
                result.Append(b.ToString("x2"));
            }
            return result.ToString();
        }

        public static bool CheckPassword(string hashedPassword, string password, string salt) 
        {
            string hash = HashPassword(password, salt);
            return hashedPassword.Equals(hash);
        }

        public static string GenerateSalt() 
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 128; i++) 
            {
                sb.Append(chars[random.Next(0, chars.Length)]);
            }
            return sb.ToString();
        }
    }
}
