using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

// Written by Owen Ravelo

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

        public bool TokenIsValid(string token) 
        {
            var jwt = new JwtSecurityTokenHandler().ReadJwtToken(token);

            var now = DateTime.Now;

            if (jwt.ValidFrom > now || jwt.ValidTo < now) 
            {
                return false;
            }
            return true;
        }

        public Guid? GetUserId(string token)
        {
            if (!TokenIsValid(token))
            {
                return null;
            }

            var jwt = new JwtSecurityTokenHandler().ReadJwtToken(token);

            Dictionary<string, string> claims = GetTokenClaims(jwt);
            string id = claims["uuid"];
            return Guid.Parse(id);
        }

        private string GenerateToken(Claim[] customPayload)
        {
            var key = new SymmetricSecurityKey(SecretKey());
            var signingCreds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                expires: DateTime.Now.AddDays(7),
                notBefore: DateTime.Now.AddDays(-1),
                claims: customPayload,
                signingCredentials: signingCreds
            );
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }
        private Dictionary<string, string> GetTokenClaims(JwtSecurityToken token)
        {
            Dictionary<string, string> claims = new Dictionary<string, string>();

            foreach (var claim in token.Claims) 
            {
                claims.Add(claim.Type, claim.Value);
            }

            return claims;
        }

        private static byte[] SecretKey()
        {
            // hardcoded secret key. Would normally be a file on the system and not saved
            string rawKey = @"=-*[B[4M5_vWU`wYM&U!\C""y_'-&YW#e^(zye$3b,;3;F%!](^6\?YmD_PMcB+Nc7yT:R>;T'M+c`gSq%E^Z:pT9<4xyAWbPB*W+=MfM6Yw~}5B9Zb5@)s-*-YGnD4NT";
            return Encoding.UTF8.GetBytes(rawKey);
        }
    }
}
