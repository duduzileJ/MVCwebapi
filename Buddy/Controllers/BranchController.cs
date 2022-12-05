using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Buddy.Data;
using Buddy.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Threading.Tasks;

namespace Buddy.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BranchController : ControllerBase
{
    private readonly BuddyDbContext _context;
    public BranchController(BuddyDbContext context)
    {
        _context = context;
    }
    [HttpGet]
    public async Task<IEnumerable<Branch>>Get()
    {
        return await _context.Branches.ToListAsync();
    }
    [HttpGet("id")]
    [ProducesResponseType(typeof(Branch), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Branch), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(int id)
    {
        var branch = await _context.Branches.FindAsync(id);
        return branch == null ? NotFound() : Ok(branch);
    }
    [HttpPost]
    [ProducesResponseType(typeof(Branch), StatusCodes.Status200OK)]
    public async Task<IActionResult> CreateBranch(Branch branch)
    {
        await _context.Branches.AddAsync(branch);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new {id = branch.BranchID}, branch);
    }
    [HttpPut]
    public async Task<IActionResult> Update(int id, Branch branch)
    {
        if(id != branch.BranchID)
            return BadRequest();
        
        _context.Entry(branch).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteBranch(int id, Branch branch)
    {
       var branchToDelete = await _context.Branches.FindAsync(id);
       if(branchToDelete == null)
       {
            return NotFound();
       }
       _context.Branches.Remove(branchToDelete);
       await _context.SaveChangesAsync();
       return NoContent();
    }
}


   