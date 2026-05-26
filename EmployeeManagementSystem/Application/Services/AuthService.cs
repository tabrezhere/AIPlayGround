using EmployeeManagementSystem.Application.Interfaces;
using EmployeeManagementSystem.Application.DTOs;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace EmployeeManagementSystem.Application.Services;

public class AuthService : IAuthService
{
    private readonly IConfiguration _configuration;

    public AuthService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task<string> LoginAsync(LoginDto loginDto)
    {
        // Validate user credentials (mocked for this example)
        if (loginDto.Email == "test@example.com" && loginDto.Password == "password")
        {
            var claims = new[] { new Claim(ClaimTypes.Name, loginDto.Email) };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        return null;
    }

    public async Task RegisterAsync(RegisterDto registerDto)
    {
        // Registration logic (mocked for this example)
    }
}