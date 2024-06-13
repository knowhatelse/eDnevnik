using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using eDnevnik___backend.DTOs.UserDto;
using Microsoft.IdentityModel.Tokens;

namespace eDnevnik___backend.Helpers;

public class JwtToken
{
    private readonly IConfiguration _configuration;

    public JwtToken()
    {
        _configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
        _configuration = _configuration.GetSection("JWT");    
    }

    public string CreateToken(GetUserDto user)
    {
        List<Claim> claims =
        [
            new Claim(ClaimTypes.NameIdentifier, user.Username),
            new Claim(ClaimTypes.GivenName, user.FirstName),
            new Claim(ClaimTypes.Surname, user.LastName),
            new Claim(ClaimTypes.Role, user.Role),
        ];

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Key"]!));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            _configuration["Issuer"],
            _configuration["Audience"],
            claims: claims, 
            expires: DateTime.Now.AddDays(7), 
            signingCredentials: credentials
            );
        
        var jwt = new JwtSecurityTokenHandler().WriteToken(token);

        return jwt;
    }
}
