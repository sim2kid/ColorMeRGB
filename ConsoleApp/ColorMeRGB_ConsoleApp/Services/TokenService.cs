using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace Services
{
    public class TokenService
    {
        public string GenerateToken(Guid userGuid) 
        {
            string UserId = userGuid.ToString();
            Claim userClaim = new Claim("uuid", UserId);
            string token = GenerateToken(new Claim[] { userClaim });
            return token;
        }

        public Guid? GetUserId(string token) 
        {
            if (!isValid(token)) 
            {
                return null;
            }
            Dictionary<string, string> claims = DecryptToken(token);
            string id = claims["uuid"];
            return Guid.Parse(id);
        }

        private string GenerateToken(Claim[] customPayload)
        {
            var key = new SymmetricSecurityKey(SecretKey());
            var signingCreds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                expires: DateTime.Now.AddDays(7),
                claims: customPayload,
                signingCredentials: signingCreds
            );
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }
        private Dictionary<string, string> DecryptToken(string jwt)
        {
            var token = new JwtSecurityTokenHandler().ReadJwtToken(jwt);
        }

        private bool isValid(string token) 
        {
            return true;
        } 
        private static byte[] SecretKey()
        {
            // TODO: Generate and access secret key via this method
            string rawKey = "Secret Key";
            return Encoding.UTF8.GetBytes(rawKey);
        }
    }
}
