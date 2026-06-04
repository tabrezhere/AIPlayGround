using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using EmployeeManagementSystem.Application.Interfaces;
using EmployeeManagementSystem.Application.DTOs;

namespace EmployeeManagementSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IEmployeeService _employeeService;
    private readonly IConfiguration _configuration;

    public AuthController(IEmployeeService employeeService, IConfiguration configuration)
    {
        _employeeService = employeeService;
        _configuration = configuration;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(EmployeeDto employeeDto)
    {
        await _employeeService.AddAsync(employeeDto);
        return Ok();
    }

    [HttpPost("login")]
    public IActionResult Login(string username, string password)
    {
        // Validate user credentials (this is just a placeholder)
        if (username == "admin" && password == "password")
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds);

            return Ok(new
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token)
            });
        }
        return Unauthorized();
    }
}