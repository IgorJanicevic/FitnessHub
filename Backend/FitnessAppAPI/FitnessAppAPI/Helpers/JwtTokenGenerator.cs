using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Web;

namespace FitnessAppAPI.Helpers
{
    public class JwtTokenGenerator
    {
        public static string GenerateToken(string userId)
        {
            var key = Encoding.ASCII.GetBytes(ConfigurationManager.AppSettings["JwtKey"]);
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
            new Claim(ClaimTypes.Name, userId)
                }),
                Expires = DateTime.UtcNow.AddMinutes(Convert.ToDouble(ConfigurationManager.AppSettings["JwtExpireMinutes"])),
                Issuer = ConfigurationManager.AppSettings["JwtIssuer"],
                Audience = ConfigurationManager.AppSettings["JwtAudience"],
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

    }
}