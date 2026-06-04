namespace EmployeeManagementSystem.Domain.Entities;

public record Employee
{
    public int Id { get; init; }
    public string Name { get; init; }
    public string Position { get; init; }
    public decimal Salary { get; init; }
}