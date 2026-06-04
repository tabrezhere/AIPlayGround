using FluentValidation;
using EmployeeManagementSystem.Application.DTOs;

namespace EmployeeManagementSystem.Application.Validators;

public class EmployeeDtoValidator : AbstractValidator<EmployeeDto>
{
    public EmployeeDtoValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Position).NotEmpty();
        RuleFor(x => x.Salary).GreaterThan(0);
    }
}