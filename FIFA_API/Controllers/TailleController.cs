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
    public class TailleController : ControllerBase
    {
        private readonly FifaDbContext _context;

        public TailleController(FifaDbContext context)
        {
            _context = context;
        }

        // GET: api/Taille
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Taille>>> GetTaille()
        {
          if (_context.Taille == null)
          {
              return NotFound();
          }
            return await _context.Taille.ToListAsync();
        }

        // GET: api/Taille/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Taille>> GetTaille(int id)
        {
          if (_context.Taille == null)
          {
              return NotFound();
          }
            var taille = await _context.Taille.FindAsync(id);

            if (taille == null)
            {
                return NotFound();
            }

            return taille;
        }

        // PUT: api/Taille/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTaille(int id, Taille taille)
        {
            if (id != taille.TailleId)
            {
                return BadRequest();
            }

            _context.Entry(taille).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TailleExists(id))
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

        // POST: api/Taille
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Taille>> PostTaille(Taille taille)
        {
          if (_context.Taille == null)
          {
              return Problem("Entity set 'FifaDbContext.Taille'  is null.");
          }
            _context.Taille.Add(taille);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTaille", new { id = taille.TailleId }, taille);
        }

        // DELETE: api/Taille/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTaille(int id)
        {
            if (_context.Taille == null)
            {
                return NotFound();
            }
            var taille = await _context.Taille.FindAsync(id);
            if (taille == null)
            {
                return NotFound();
            }

            _context.Taille.Remove(taille);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TailleExists(int id)
        {
            return (_context.Taille?.Any(e => e.TailleId == id)).GetValueOrDefault();
        }
    }
}
