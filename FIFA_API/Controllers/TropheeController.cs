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
    public class TropheeController : ControllerBase
    {
        private readonly FifaDbContext _context;

        public TropheeController(FifaDbContext context)
        {
            _context = context;
        }

        // GET: api/Trophee
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Trophee>>> GetTrophee()
        {
          if (_context.Trophee == null)
          {
              return NotFound();
          }
            return await _context.Trophee.ToListAsync();
        }

        // GET: api/Trophee/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Trophee>> GetTrophee(int id)
        {
          if (_context.Trophee == null)
          {
              return NotFound();
          }
            var trophee = await _context.Trophee.FindAsync(id);

            if (trophee == null)
            {
                return NotFound();
            }

            return trophee;
        }

        // PUT: api/Trophee/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrophee(int id, Trophee trophee)
        {
            if (id != trophee.TropheeId)
            {
                return BadRequest();
            }

            _context.Entry(trophee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TropheeExists(id))
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

        // POST: api/Trophee
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Trophee>> PostTrophee(Trophee trophee)
        {
          if (_context.Trophee == null)
          {
              return Problem("Entity set 'FifaDbContext.Trophee'  is null.");
          }
            _context.Trophee.Add(trophee);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTrophee", new { id = trophee.TropheeId }, trophee);
        }

        // DELETE: api/Trophee/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrophee(int id)
        {
            if (_context.Trophee == null)
            {
                return NotFound();
            }
            var trophee = await _context.Trophee.FindAsync(id);
            if (trophee == null)
            {
                return NotFound();
            }

            _context.Trophee.Remove(trophee);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TropheeExists(int id)
        {
            return (_context.Trophee?.Any(e => e.TropheeId == id)).GetValueOrDefault();
        }
    }
}
