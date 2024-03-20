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
    public class AnecdoteController : ControllerBase
    {
        private readonly FifaDbContext _context;

        public AnecdoteController(FifaDbContext context)
        {
            _context = context;
        }

        // GET: api/Anecdote
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Anecdote>>> GetAnecdote()
        {
          if (_context.Anecdote == null)
          {
              return NotFound();
          }
            return await _context.Anecdote.ToListAsync();
        }

        // GET: api/Anecdote/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Anecdote>> GetAnecdote(int id)
        {
          if (_context.Anecdote == null)
          {
              return NotFound();
          }
            var anecdote = await _context.Anecdote.FindAsync(id);

            if (anecdote == null)
            {
                return NotFound();
            }

            return anecdote;
        }

        // PUT: api/Anecdote/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnecdote(int id, Anecdote anecdote)
        {
            if (id != anecdote.AnecdoteId)
            {
                return BadRequest();
            }

            _context.Entry(anecdote).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnecdoteExists(id))
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

        // POST: api/Anecdote
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Anecdote>> PostAnecdote(Anecdote anecdote)
        {
          if (_context.Anecdote == null)
          {
              return Problem("Entity set 'FifaDbContext.Anecdote'  is null.");
          }
            _context.Anecdote.Add(anecdote);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAnecdote", new { id = anecdote.AnecdoteId }, anecdote);
        }

        // DELETE: api/Anecdote/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnecdote(int id)
        {
            if (_context.Anecdote == null)
            {
                return NotFound();
            }
            var anecdote = await _context.Anecdote.FindAsync(id);
            if (anecdote == null)
            {
                return NotFound();
            }

            _context.Anecdote.Remove(anecdote);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AnecdoteExists(int id)
        {
            return (_context.Anecdote?.Any(e => e.AnecdoteId == id)).GetValueOrDefault();
        }
    }
}
