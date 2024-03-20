using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FIFA_API.Models.EntityFramework;

namespace FIFA_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoteController : ControllerBase
    {
        private readonly FifaDbContext _context;

        public VoteController(FifaDbContext context)
        {
            _context = context;
        }

        // GET: api/Vote
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vote>>> GetVote()
        {
          if (_context.Vote == null)
          {
              return NotFound();
          }
            return await _context.Vote.ToListAsync();
        }

        // GET: api/Vote/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Vote>> GetVote(int id)
        {
          if (_context.Vote == null)
          {
              return NotFound();
          }
            var vote = await _context.Vote.FindAsync(id);

            if (vote == null)
            {
                return NotFound();
            }

            return vote;
        }

        // PUT: api/Vote/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVote(int id, Vote vote)
        {
            if (id != vote.UtilisateurId)
            {
                return BadRequest();
            }

            _context.Entry(vote).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VoteExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Vote
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Vote>> PostVote(Vote vote)
        {
          if (_context.Vote == null)
          {
              return Problem("Entity set 'FifaDbContext.Vote'  is null.");
          }
            _context.Vote.Add(vote);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (VoteExists(vote.UtilisateurId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetVote", new { id = vote.UtilisateurId }, vote);
        }

        // DELETE: api/Vote/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVote(int id)
        {
            if (_context.Vote == null)
            {
                return NotFound();
            }
            var vote = await _context.Vote.FindAsync(id);
            if (vote == null)
            {
                return NotFound();
            }

            _context.Vote.Remove(vote);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VoteExists(int id)
        {
            return (_context.Vote?.Any(e => e.UtilisateurId == id)).GetValueOrDefault();
        }
    }
}
