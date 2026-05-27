using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace EmployeeManagementSystem.Infrastructure.SeedData;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using var context = new AppDbContext(serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>());
        if (context.Employees.Any()) return;

        context.Employees.AddRange(
            new Employee { FirstName = "John", LastName = "Doe", Email = "john.doe@example.com", Role = "Manager" },
            new Employee { FirstName = "Jane", LastName = "Doe", Email = "jane.doe@example.com", Role = "Employee" }
        );
        context.SaveChanges();
    }
}