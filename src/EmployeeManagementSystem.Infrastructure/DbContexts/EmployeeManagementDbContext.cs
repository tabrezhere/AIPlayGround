using Microsoft.EntityFrameworkCore;
using EmployeeManagementSystem.Domain.Entities;

namespace EmployeeManagementSystem.Infrastructure.DbContexts;

public class EmployeeManagementDbContext : DbContext
{
    public EmployeeManagementDbContext(DbContextOptions<EmployeeManagementDbContext> options) : base(options) { }

    public DbSet<Employee> Employees { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>().HasKey(e => e.Id);
    }
}