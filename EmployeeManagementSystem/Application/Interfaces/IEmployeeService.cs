namespace EmployeeManagementSystem.Application.Interfaces;

public interface IEmployeeService
{
    Task<EmployeeDto> GetByIdAsync(int id);
    Task<IEnumerable<EmployeeDto>> GetAllAsync();
    Task AddAsync(EmployeeDto employeeDto);
    Task UpdateAsync(EmployeeDto employeeDto);
    Task DeleteAsync(int id);
}