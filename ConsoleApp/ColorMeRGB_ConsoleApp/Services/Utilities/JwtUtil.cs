using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;

namespace Services.Utilities
{
    public static class JwtUtil
    {
        public static string GenerateToken(Claim[] customPayload) 
        {
            var key = new SymmetricSecurityKey(SecretKey());
            var signInCred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                expires: DateTime.Now.AddDays(7),
                claims: customPayload,
                signingCredentials: signInCred
            );
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }
        public static Dictionary<string, string> DecryptToken(string jwt) 
        {
            
        }
        private static byte[] SecretKey() 
        {
            // TODO: Generate and access secret key via this method
            string rawKey = "Secret Key";
            return Encoding.UTF8.GetBytes(rawKey);
        }
    }
}
