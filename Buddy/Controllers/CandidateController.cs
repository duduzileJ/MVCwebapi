using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Buddy.Data;
using Buddy.Models;
using Microsoft.EntityFrameworkCore;

namespace Buddy.Controllers;

[Route("api/[controller]")]
[ApiController]

public class CandidateController : ControllerBase
{
    private readonly BuddyDbContext _context;
    public CandidateController(BuddyDbContext context)
    {
        _context = context;
    }
    [HttpGet]
    public async Task<IEnumerable<Candidate>>Get()
    {
        return await _context.Candidates.ToListAsync();
    }
    [HttpGet("id")]
    [ProducesResponseType(typeof(Candidate), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Candidate), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(int id)
    {
        var candidate = await _context.Candidates.FindAsync(id);
        return candidate == null ? NotFound() : Ok(candidate);
    }
    [HttpPost]
    [ProducesResponseType(typeof(Candidate), StatusCodes.Status200OK)]
    public async Task<IActionResult> CreateCandidate(Candidate candidate)
    {
        await _context.Candidates.AddAsync(candidate);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new {id = candidate.CandidateID}, candidate);
    }
     [HttpPut]
    public async Task<IActionResult> UpdateCandidate(int id, Candidate candidate)
    {
        if(id != candidate.CandidateID)
            return BadRequest();
        
        _context.Entry(candidate).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteCandidate(int id, Candidate candidate)
    {
       var candidateToDelete = await _context.Candidates.FindAsync(id);
       if(candidateToDelete == null)
       {
            return NotFound();
       }
       _context.Candidates.Remove(candidateToDelete);
       await _context.SaveChangesAsync();
       return NoContent();
    }

   
}