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
        private static readonly char[] chars = "abcdefghijklmnopqrstuvwxyz1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
        private static readonly Random random = new Random();

        public static string HashPassword(string password, string salt, DateTime accountCreationTime) 
        {
            int reps = GenerateReps(accountCreationTime);
            return HashPassword(password + salt, reps);
        }

        private static string HashPassword(string passwordSalt, int reps = 1) 
        {
            if (reps < 1)
            {
                reps = 1;
            }
            byte[] byteword = Encoding.Unicode.GetBytes(passwordSalt);
            SHA512 sha512 = SHA512.Create();
            for (int i = 0; i < reps; i++) 
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

        public static bool CheckPassword(string hashedPassword, string password, string salt, DateTime accountCreationTime) 
        {
            int reps = GenerateReps(accountCreationTime);
            string hash = HashPassword(password + salt, reps);
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

        private static int GenerateReps(DateTime timeSeed) 
        {
            Random r = new Random((int)(timeSeed.Ticks / TimeSpan.TicksPerMillisecond));
            return r.Next() % 50;
        }
    }
}
