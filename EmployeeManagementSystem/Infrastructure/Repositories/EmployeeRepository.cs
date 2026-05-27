using EmployeeManagementSystem.Domain.Interfaces;
using EmployeeManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem.Infrastructure.Repositories;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly AppDbContext _context;

    public EmployeeRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Employee> GetByIdAsync(int id) => await _context.Employees.FindAsync(id);

    public async Task<IEnumerable<Employee>> GetAllAsync() => await _context.Employees.ToListAsync();

    public async Task AddAsync(Employee employee) => await _context.Employees.AddAsync(employee);

    public async Task UpdateAsync(Employee employee) => _context.Employees.Update(employee);

    public async Task DeleteAsync(int id)
    {
        var employee = await GetByIdAsync(id);
        if (employee != null) _context.Employees.Remove(employee);
    }
}