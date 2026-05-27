using EmployeeManagementSystem.Domain.Interfaces;
using EmployeeManagementSystem.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Application.Services;

public class EmployeeService
{
    private readonly IEmployeeRepository _employeeRepository;

    public EmployeeService(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public async Task<EmployeeDto> GetByIdAsync(int id)
    {
        var employee = await _employeeRepository.GetByIdAsync(id);
        return new EmployeeDto { Id = employee.Id, FirstName = employee.FirstName, LastName = employee.LastName, Email = employee.Email, Role = employee.Role };
    }

    public async Task<IEnumerable<EmployeeDto>> GetAllAsync()
    {
        var employees = await _employeeRepository.GetAllAsync();
        return employees.Select(e => new EmployeeDto { Id = e.Id, FirstName = e.FirstName, LastName = e.LastName, Email = e.Email, Role = e.Role });
    }

    public async Task AddAsync(EmployeeDto employeeDto)
    {
        var employee = new Employee { FirstName = employeeDto.FirstName, LastName = employeeDto.LastName, Email = employeeDto.Email, Role = employeeDto.Role };
        await _employeeRepository.AddAsync(employee);
    }

    public async Task UpdateAsync(EmployeeDto employeeDto)
    {
        var employee = new Employee { Id = employeeDto.Id, FirstName = employeeDto.FirstName, LastName = employeeDto.LastName, Email = employeeDto.Email, Role = employeeDto.Role };
        await _employeeRepository.UpdateAsync(employee);
    }

    public async Task DeleteAsync(int id)
    {
        await _employeeRepository.DeleteAsync(id);
    }
}