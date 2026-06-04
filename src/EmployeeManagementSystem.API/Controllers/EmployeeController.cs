using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using EmployeeManagementSystem.Application.Interfaces;
using EmployeeManagementSystem.Application.DTOs;

namespace EmployeeManagementSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeService _employeeService;

    public EmployeeController(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var employees = await _employeeService.GetAllAsync();
        return Ok(employees);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var employee = await _employeeService.GetByIdAsync(id);
        return Ok(employee);
    }

    [HttpPost]
    public async Task<IActionResult> Add(EmployeeDto employeeDto)
    {
        await _employeeService.AddAsync(employeeDto);
        return CreatedAtAction(nameof(GetById), new { id = employeeDto.Id }, employeeDto);
    }

    [HttpPut]
    public async Task<IActionResult> Update(EmployeeDto employeeDto)
    {
        await _employeeService.UpdateAsync(employeeDto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _employeeService.DeleteAsync(id);
        return NoContent();
    }
}