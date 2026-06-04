namespace EmployeeManagementSystem.Application.DTOs;

public record EmployeeDto
{
    public int Id { get; init; }
    public string Name { get; init; }
    public string Position { get; init; }
    public decimal Salary { get; init; }
}