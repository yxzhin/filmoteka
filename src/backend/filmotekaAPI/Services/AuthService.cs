using filmotekaAPI.Interfaces.AuthInterfaces;
using filmotekaAPI.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace filmotekaAPI.Services
{
    public class AuthService(IConfiguration config) : IAuthService
    {
        private readonly IConfiguration _config = config;

        public string GenerateToken(Korisnik korisnik)
        {
            List<Claim> claims =
            [
            new Claim(ClaimTypes.NameIdentifier,
                korisnik.Id.ToString()),

            new Claim(ClaimTypes.Name,
                korisnik.Ime),

            new Claim(ClaimTypes.Role,
                korisnik.Uloga.ToString())
        ];

            SymmetricSecurityKey key = new(
                Encoding.UTF8.GetBytes(
                    _config["Jwt:Key"]!
                ));

            SigningCredentials creds = new(
                key,
                SecurityAlgorithms.HmacSha256);

            JwtSecurityToken token = new(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(12),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler()
                .WriteToken(token);
        }
    }
}
