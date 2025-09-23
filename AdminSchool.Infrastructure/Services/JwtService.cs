using AdminSchool.Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AdminSchool.Infrastructure.Services
{
    public class JwtService(IConfiguration _configuration) : IJwtService
    {

        private readonly string _key = _configuration["Jwt:Key"];
        private readonly string _iuuser = _configuration["Jwt:Issuer"];
        private readonly string _audience = _configuration["Jwt:Audience"];
        public string GenerateToken(string userId, string username, IEnumerable<string> roles)
        {
            var claims = new List<Claim> {
             new Claim(JwtRegisteredClaimNames.Sub, userId),

             new Claim(JwtRegisteredClaimNames.UniqueName, username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

            var keyBytes = Encoding.UTF8.GetBytes(_key);
            var securityKey = new SymmetricSecurityKey(keyBytes);
            var credencitals = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
          issuer: _iuuser,
          audience: _audience,
          claims: claims,
          expires: DateTime.UtcNow.AddDays(1),
          signingCredentials: credencitals
          );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
