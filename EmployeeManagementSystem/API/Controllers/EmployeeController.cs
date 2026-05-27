using Microsoft.AspNetCore.Mvc;
using EmployeeManagementSystem.Application.Services;
using EmployeeManagementSystem.Application.DTOs;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeeController : ControllerBase
{
    private readonly EmployeeService _employeeService;

    public EmployeeController(EmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var employee = await _employeeService.GetByIdAsync(id);
        return Ok(employee);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var employees = await _employeeService.GetAllAsync();
        return Ok(employees);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] EmployeeDto employeeDto)
    {
        await _employeeService.AddAsync(employeeDto);
        return CreatedAtAction(nameof(GetById), new { id = employeeDto.Id }, employeeDto);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] EmployeeDto employeeDto)
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