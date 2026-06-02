using FluentValidation;
using EmployeeManagementSystem.Application.DTOs;

public class EmployeeValidator : AbstractValidator<EmployeeDto>
{
    public EmployeeValidator()
    {
        RuleFor(e => e.FirstName).NotEmpty();
        RuleFor(e => e.LastName).NotEmpty();
        RuleFor(e => e.Position).NotEmpty();
        RuleFor(e => e.Department).NotEmpty();
    }
}