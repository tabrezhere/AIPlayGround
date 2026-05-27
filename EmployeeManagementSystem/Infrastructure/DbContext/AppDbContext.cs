using Microsoft.EntityFrameworkCore;
using EmployeeManagementSystem.Domain.Entities;

namespace EmployeeManagementSystem.Infrastructure.DbContext;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Employee> Employees { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>().ToTable("Employees");
    }
}