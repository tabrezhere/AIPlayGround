namespace EmployeeManagementSystem.Application.DTOs;

public record EmployeeDto
{
    public int Id { get; init; }
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public string Position { get; init; }
    public string Department { get; init; }
}