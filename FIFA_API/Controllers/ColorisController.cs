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
    public class ColorisController : ControllerBase
    {
        private readonly FifaDbContext _context;

        public ColorisController(FifaDbContext context)
        {
            _context = context;
        }

        // GET: api/Coloris
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Coloris>>> GetColoris()
        {
          if (_context.Coloris == null)
          {
              return NotFound();
          }
            return await _context.Coloris.ToListAsync();
        }

        // GET: api/Coloris/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Coloris>> GetColoris(int id)
        {
          if (_context.Coloris == null)
          {
              return NotFound();
          }
            var coloris = await _context.Coloris.FindAsync(id);

            if (coloris == null)
            {
                return NotFound();
            }

            return coloris;
        }

        // PUT: api/Coloris/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutColoris(int id, Coloris coloris)
        {
            if (id != coloris.ColorisId)
            {
                return BadRequest();
            }

            _context.Entry(coloris).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ColorisExists(id))
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

        // POST: api/Coloris
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Coloris>> PostColoris(Coloris coloris)
        {
          if (_context.Coloris == null)
          {
              return Problem("Entity set 'FifaDbContext.Coloris'  is null.");
          }
            _context.Coloris.Add(coloris);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetColoris", new { id = coloris.ColorisId }, coloris);
        }

        // DELETE: api/Coloris/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteColoris(int id)
        {
            if (_context.Coloris == null)
            {
                return NotFound();
            }
            var coloris = await _context.Coloris.FindAsync(id);
            if (coloris == null)
            {
                return NotFound();
            }

            _context.Coloris.Remove(coloris);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ColorisExists(int id)
        {
            return (_context.Coloris?.Any(e => e.ColorisId == id)).GetValueOrDefault();
        }
    }
}
