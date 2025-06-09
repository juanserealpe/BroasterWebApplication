using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BroasterWebApp.Entities;
using BroasterWebApp.interfaces;
using Microsoft.IdentityModel.Tokens;

namespace BroasterWebApp.services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateToken(Employee prmEmployee)
        {
            Console.WriteLine("ENtrando en GenerateTOken,,,,");
            var key = _configuration["Jwt:Key"];
            var issuer = _configuration["Jwt:Issuer"];
            var audience = _configuration["Jwt:Audience"];
            var expires = DateTime.UtcNow.AddMinutes(double.Parse(_configuration["Jwt:ExpiresInMinutes"]));

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, prmEmployee.FirstName),
                new Claim(ClaimTypes.Role, prmEmployee.Role.RoleType.TypeRole),
            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: expires,
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}