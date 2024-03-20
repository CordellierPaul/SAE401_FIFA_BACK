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
    public class LangueController : ControllerBase
    {
        private readonly FifaDbContext _context;

        public LangueController(FifaDbContext context)
        {
            _context = context;
        }

        // GET: api/Langue
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Langue>>> GetLangue()
        {
          if (_context.Langue == null)
          {
              return NotFound();
          }
            return await _context.Langue.ToListAsync();
        }

        // GET: api/Langue/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Langue>> GetLangue(int id)
        {
          if (_context.Langue == null)
          {
              return NotFound();
          }
            var langue = await _context.Langue.FindAsync(id);

            if (langue == null)
            {
                return NotFound();
            }

            return langue;
        }

        // PUT: api/Langue/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLangue(int id, Langue langue)
        {
            if (id != langue.LangueId)
            {
                return BadRequest();
            }

            _context.Entry(langue).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LangueExists(id))
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

        // POST: api/Langue
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Langue>> PostLangue(Langue langue)
        {
          if (_context.Langue == null)
          {
              return Problem("Entity set 'FifaDbContext.Langue'  is null.");
          }
            _context.Langue.Add(langue);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLangue", new { id = langue.LangueId }, langue);
        }

        // DELETE: api/Langue/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLangue(int id)
        {
            if (_context.Langue == null)
            {
                return NotFound();
            }
            var langue = await _context.Langue.FindAsync(id);
            if (langue == null)
            {
                return NotFound();
            }

            _context.Langue.Remove(langue);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LangueExists(int id)
        {
            return (_context.Langue?.Any(e => e.LangueId == id)).GetValueOrDefault();
        }
    }
}
