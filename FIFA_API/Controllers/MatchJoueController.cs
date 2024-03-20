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
    public class MatchJoueController : ControllerBase
    {
        private readonly FifaDbContext _context;

        public MatchJoueController(FifaDbContext context)
        {
            _context = context;
        }

        // GET: api/MatchJoue
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MatchJoue>>> GetMatchJoue()
        {
          if (_context.MatchJoue == null)
          {
              return NotFound();
          }
            return await _context.MatchJoue.ToListAsync();
        }

        // GET: api/MatchJoue/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MatchJoue>> GetMatchJoue(int id)
        {
          if (_context.MatchJoue == null)
          {
              return NotFound();
          }
            var matchJoue = await _context.MatchJoue.FindAsync(id);

            if (matchJoue == null)
            {
                return NotFound();
            }

            return matchJoue;
        }

        // PUT: api/MatchJoue/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMatchJoue(int id, MatchJoue matchJoue)
        {
            if (id != matchJoue.JoueurId)
            {
                return BadRequest();
            }

            _context.Entry(matchJoue).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MatchJoueExists(id))
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

        // POST: api/MatchJoue
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MatchJoue>> PostMatchJoue(MatchJoue matchJoue)
        {
          if (_context.MatchJoue == null)
          {
              return Problem("Entity set 'FifaDbContext.MatchJoue'  is null.");
          }
            _context.MatchJoue.Add(matchJoue);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MatchJoueExists(matchJoue.JoueurId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMatchJoue", new { id = matchJoue.JoueurId }, matchJoue);
        }

        // DELETE: api/MatchJoue/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMatchJoue(int id)
        {
            if (_context.MatchJoue == null)
            {
                return NotFound();
            }
            var matchJoue = await _context.MatchJoue.FindAsync(id);
            if (matchJoue == null)
            {
                return NotFound();
            }

            _context.MatchJoue.Remove(matchJoue);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MatchJoueExists(int id)
        {
            return (_context.MatchJoue?.Any(e => e.JoueurId == id)).GetValueOrDefault();
        }
    }
}
