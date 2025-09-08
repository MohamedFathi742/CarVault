using CarVault.Application.Interfaces.Security;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CarVault.Infrastructure.Security;
public class JwtService(IConfiguration configuration) : IJwtService
{
    private readonly IConfiguration _configuration = configuration;

    public string GenerateToken(string userId, string email, IList<string> roles)
    {

        var jwtSettings = _configuration.GetSection("JWT");
        var claims = new List<Claim>
        {
        new Claim(JwtRegisteredClaimNames.Sub,userId),
        new Claim(JwtRegisteredClaimNames.Email,email),
        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        
        };
        foreach (var role in roles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role));
        }
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"]!));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(

            issuer: jwtSettings["Issuer"],
            audience: jwtSettings["Audience"],
            claims:claims,
            expires:DateTime.UtcNow.AddMinutes(Convert.ToDouble(jwtSettings["DurationInMinutes"])),
            signingCredentials:creds


            );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
