using EmployeeManagementSystem.Application.DTOs;
namespace EmployeeManagementSystem.Application.Services;

public interface IEmployeeService
{
    Task<IEnumerable<EmployeeDto>> GetAllAsync();
    Task<EmployeeDto> GetByIdAsync(int id);
    Task AddAsync(EmployeeDto employeeDto);
    Task UpdateAsync(EmployeeDto employeeDto);
    Task DeleteAsync(int id);
}