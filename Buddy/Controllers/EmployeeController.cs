using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Buddy.Data;
using Buddy.Models;
using Microsoft.EntityFrameworkCore;

namespace Buddy.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmployeeController : ControllerBase
{
    private readonly BuddyDbContext _context;
    public EmployeeController(BuddyDbContext context)
    {
        _context = context;
    }
    [HttpGet]
    public async Task<IEnumerable<Employee>>Get()
    {
        return await _context.Employees.ToListAsync();
    }
    [HttpGet("id")]
    [ProducesResponseType(typeof(Employee), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Employee), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(int id)
    {
        var employee = await _context.Employees.FindAsync(id);
        return employee == null ? NotFound() : Ok(employee);
    }
    [HttpPost]
    [ProducesResponseType(typeof(Employee), StatusCodes.Status200OK)]
    public async Task<IActionResult> CreateEmployee(Employee employee)
    {
        await _context.Employees.AddAsync(employee);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new {id = employee.EmpID}, employee);
    }
    
    [HttpPut]
    public async Task<IActionResult> UpdateEmployee(int id, Employee employee)
    {
        if(id != employee.EmpID)
            return BadRequest();
        
        _context.Entry(employee).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteEmployee(int id, Employee employee)
    {
       var employeeToDelete = await _context.Employees.FindAsync(id);
       if(employeeToDelete == null)
       {
            return NotFound();
       }
       _context.Employees.Remove(employeeToDelete);
       await _context.SaveChangesAsync();
       return NoContent();
    }

   
}