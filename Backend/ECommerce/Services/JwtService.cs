using ECommerce.DTO;
using ECommerce.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace ECommerce.Services
{
    public class JwtService
    {
        private readonly IConfiguration config;
        private readonly UserManager<ApplicationUser> userManager;
        public JwtService(IConfiguration config, UserManager<ApplicationUser> userManager) { 
            this.config = config;
            this.userManager = userManager;
        }
        private async Task<ClaimsIdentity> GenerateClaimsAsync(ApplicationUser user)
        {
            var claims = new ClaimsIdentity();
            claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
            claims.AddClaim(new Claim(ClaimTypes.Email, user.Email));
            claims.AddClaim(new Claim(JwtRegisteredClaimNames.Jti, new Guid().ToString()));
            var roles = await userManager.GetRolesAsync(user);
            foreach (var role in roles)
                claims.AddClaim(new Claim(ClaimTypes.Role, role));
            return claims;
        }
        public async Task<string> createAsync(ApplicationUser user)
        {
            var handler = new JwtSecurityTokenHandler();
            var privateKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JWT:SecretKey"]));
            var credentials = new SigningCredentials(privateKey, SecurityAlgorithms.HmacSha256);
            var claims = await GenerateClaimsAsync(user);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = config["JWT:ValidIssuer"],
                Audience = config["JWT:ValidAudience"],
                SigningCredentials = credentials,
                Expires = DateTime.UtcNow.AddHours(1),
                Subject = claims
            };
            var token = handler.CreateToken(tokenDescriptor);
            return handler.WriteToken(token);
        }
    }
}
