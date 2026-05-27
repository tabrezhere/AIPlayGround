using FluentValidation;
using EmployeeManagementSystem.Application.DTOs;

namespace EmployeeManagementSystem.Application.Validators;

public class EmployeeDtoValidator : AbstractValidator<EmployeeDto>
{
    public EmployeeDtoValidator()
    {
        RuleFor(x => x.FirstName).NotEmpty();
        RuleFor(x => x.LastName).NotEmpty();
        RuleFor(x => x.Email).EmailAddress();
        RuleFor(x => x.Role).NotEmpty();
    }
}