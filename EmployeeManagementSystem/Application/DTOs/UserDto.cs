namespace EmployeeManagementSystem.Application.DTOs;

public record UserDto
{
    public string Username { get; init; }
    public string Password { get; init; }
}