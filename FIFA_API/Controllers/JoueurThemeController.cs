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
    public class JoueurThemeController : ControllerBase
    {
        private readonly FifaDbContext _context;

        public JoueurThemeController(FifaDbContext context)
        {
            _context = context;
        }

        // GET: api/JoueurTheme
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JoueurTheme>>> GetJoueurTheme()
        {
          if (_context.JoueurTheme == null)
          {
              return NotFound();
          }
            return await _context.JoueurTheme.ToListAsync();
        }

        // GET: api/JoueurTheme/5
        [HttpGet("{id}")]
        public async Task<ActionResult<JoueurTheme>> GetJoueurTheme(int id)
        {
          if (_context.JoueurTheme == null)
          {
              return NotFound();
          }
            var joueurTheme = await _context.JoueurTheme.FindAsync(id);

            if (joueurTheme == null)
            {
                return NotFound();
            }

            return joueurTheme;
        }

        // PUT: api/JoueurTheme/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJoueurTheme(int id, JoueurTheme joueurTheme)
        {
            if (id != joueurTheme.ThemeId)
            {
                return BadRequest();
            }

            _context.Entry(joueurTheme).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JoueurThemeExists(id))
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

        // POST: api/JoueurTheme
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<JoueurTheme>> PostJoueurTheme(JoueurTheme joueurTheme)
        {
          if (_context.JoueurTheme == null)
          {
              return Problem("Entity set 'FifaDbContext.JoueurTheme'  is null.");
          }
            _context.JoueurTheme.Add(joueurTheme);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (JoueurThemeExists(joueurTheme.ThemeId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetJoueurTheme", new { id = joueurTheme.ThemeId }, joueurTheme);
        }

        // DELETE: api/JoueurTheme/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJoueurTheme(int id)
        {
            if (_context.JoueurTheme == null)
            {
                return NotFound();
            }
            var joueurTheme = await _context.JoueurTheme.FindAsync(id);
            if (joueurTheme == null)
            {
                return NotFound();
            }

            _context.JoueurTheme.Remove(joueurTheme);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool JoueurThemeExists(int id)
        {
            return (_context.JoueurTheme?.Any(e => e.ThemeId == id)).GetValueOrDefault();
        }
    }
}
