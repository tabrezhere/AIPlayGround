using EmployeeManagementSystem.Application.DTOs;
using EmployeeManagementSystem.Domain.Entities;
using EmployeeManagementSystem.Domain.Interfaces;

namespace EmployeeManagementSystem.Application.Services;

public class EmployeeService : IEmployeeService
{
    private readonly IEmployeeRepository _employeeRepository;

    public EmployeeService(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public async Task<IEnumerable<EmployeeDto>> GetAllAsync()
    {
        var employees = await _employeeRepository.GetAllAsync();
        return employees.Select(e => new EmployeeDto { Id = e.Id, Name = e.Name, Position = e.Position, Salary = e.Salary });
    }

    public async Task<EmployeeDto> GetByIdAsync(int id)
    {
        var employee = await _employeeRepository.GetByIdAsync(id);
        return new EmployeeDto { Id = employee.Id, Name = employee.Name, Position = employee.Position, Salary = employee.Salary };
    }

    public async Task AddAsync(EmployeeDto employeeDto)
    {
        var employee = new Employee { Name = employeeDto.Name, Position = employeeDto.Position, Salary = employeeDto.Salary };
        await _employeeRepository.AddAsync(employee);
    }

    public async Task UpdateAsync(EmployeeDto employeeDto)
    {
        var employee = new Employee { Id = employeeDto.Id, Name = employeeDto.Name, Position = employeeDto.Position, Salary = employeeDto.Salary };
        await _employeeRepository.UpdateAsync(employee);
    }

    public async Task DeleteAsync(int id)
    {
        await _employeeRepository.DeleteAsync(id);
    }
}