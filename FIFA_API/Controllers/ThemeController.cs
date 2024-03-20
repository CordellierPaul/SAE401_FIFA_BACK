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
    public class ThemeController : ControllerBase
    {
        private readonly FifaDbContext _context;

        public ThemeController(FifaDbContext context)
        {
            _context = context;
        }

        // GET: api/Theme
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Theme>>> GetTheme()
        {
          if (_context.Theme == null)
          {
              return NotFound();
          }
            return await _context.Theme.ToListAsync();
        }

        // GET: api/Theme/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Theme>> GetTheme(int id)
        {
          if (_context.Theme == null)
          {
              return NotFound();
          }
            var theme = await _context.Theme.FindAsync(id);

            if (theme == null)
            {
                return NotFound();
            }

            return theme;
        }

        // PUT: api/Theme/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTheme(int id, Theme theme)
        {
            if (id != theme.ThemeId)
            {
                return BadRequest();
            }

            _context.Entry(theme).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ThemeExists(id))
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

        // POST: api/Theme
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Theme>> PostTheme(Theme theme)
        {
          if (_context.Theme == null)
          {
              return Problem("Entity set 'FifaDbContext.Theme'  is null.");
          }
            _context.Theme.Add(theme);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTheme", new { id = theme.ThemeId }, theme);
        }

        // DELETE: api/Theme/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTheme(int id)
        {
            if (_context.Theme == null)
            {
                return NotFound();
            }
            var theme = await _context.Theme.FindAsync(id);
            if (theme == null)
            {
                return NotFound();
            }

            _context.Theme.Remove(theme);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ThemeExists(int id)
        {
            return (_context.Theme?.Any(e => e.ThemeId == id)).GetValueOrDefault();
        }
    }
}
