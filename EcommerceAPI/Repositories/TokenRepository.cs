using ECommerceAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace EcommerceAPI.Repositories
{
    public class TokenRepository : ITokenRepository
    {
        private readonly IConfiguration configuration;

        public TokenRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public string GenerateToken(IdentityUser user, List<string> roles)
        {
            // Create claims
            var claims = new List<Claim>();

            // Add Email
            claims.Add(new Claim(ClaimTypes.Email, user.Email));

            // Add Roles
            foreach (var role in roles) 
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            // Key and Signing Credentials
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                configuration["Jwt:Issuer"],
                configuration["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(double.Parse(configuration["Jwt:ExpireyMinutes"])),
                signingCredentials: credentials
                );

            // Serialize and Return the Token
            var tokenWriter = new JwtSecurityTokenHandler();

            return tokenWriter.WriteToken(token);
        }
    }
}
