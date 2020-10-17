using System;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Emporos.API.Auth.Domain.UserAggregate;
using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.Extensions.Options;
using Emporos.API.Auth.Common.Settings;

namespace Emporos.API.Auth.Domain.Internal
{
    public static class JWTTokenGenerator
    {
        public static string GenerateToken(UserEntity user, IOptions<AppSettings> appSettings)
        {
            var secretKey = appSettings.Value.JWT.SecretKey;
            var issuer = appSettings.Value.JWT.Issuer;
            var audience = appSettings.Value.JWT.Audience;
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = ClaimsIdentity(user);

            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials
            );

            var tokenHandler = new JwtSecurityTokenHandler();
            var stringToken = tokenHandler.WriteToken(token);

            return stringToken;
        }

        private static Claim[] ClaimsIdentity(UserEntity user)
        {
            Claim[] getClaims()
            {
                List<Claim> claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.Name, user.Login));
                foreach (var item in user.UserRoles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, item.Role));
                }
                return claims.ToArray();
            }

            return getClaims();
        }
    }
}
