using Microsoft.AspNetCore.Mvc;
using EmployeeManagementSystem.Application.DTOs;
using EmployeeManagementSystem.Application.Services;

namespace EmployeeManagementSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IEmployeeService _employeeService;

    public AuthController(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(UserDto userDto)
    {
        // Implementation for user login
        return Ok();
    }
}