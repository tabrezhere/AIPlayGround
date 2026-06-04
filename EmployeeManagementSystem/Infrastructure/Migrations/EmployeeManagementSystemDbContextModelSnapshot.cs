using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeManagementSystem.Infrastructure.Migrations;

[DbContext(typeof(AppDbContext))]
partial class EmployeeManagementSystemDbContextModelSnapshot : ModelSnapshot
{
    protected override void BuildModel(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity("EmployeeManagementSystem.Domain.Entities.Employee", b =>
        {
            b.Property<int>("Id")
                .ValueGeneratedOnAdd();
            b.Property<string>("FirstName")
                .IsRequired();
            b.Property<string>("LastName")
                .IsRequired();
            b.Property<string>("Email")
                .IsRequired();
            b.Property<string>("Role")
                .IsRequired();
            b.HasKey("Id");
            b.ToTable("Employees");
        });
    }
}