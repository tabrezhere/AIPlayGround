using FluentValidation;
using EmployeeManagementSystem.Application.DTOs;

namespace EmployeeManagementSystem.Application.Validators;

public class EmployeeDtoValidator : AbstractValidator<EmployeeDto>
{
    public EmployeeDtoValidator()
    {
        RuleFor(e => e.FirstName).NotEmpty();
        RuleFor(e => e.LastName).NotEmpty();
        RuleFor(e => e.Email).EmailAddress();
        RuleFor(e => e.Role).NotEmpty();
    }
}