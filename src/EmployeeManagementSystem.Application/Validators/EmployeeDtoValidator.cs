using FluentValidation;
using EmployeeManagementSystem.Application.DTOs;

namespace EmployeeManagementSystem.Application.Validators;

public class EmployeeDtoValidator : AbstractValidator<EmployeeDto>
{
    public EmployeeDtoValidator()
    {
        RuleFor(e => e.Name).NotEmpty();
        RuleFor(e => e.Position).NotEmpty();
        RuleFor(e => e.Salary).GreaterThan(0);
    }
}