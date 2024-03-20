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
    public class ActiviteController : ControllerBase
    {
        private readonly FifaDbContext _context;

        public ActiviteController(FifaDbContext context)
        {
            _context = context;
        }

        // GET: api/Activite
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Activite>>> GetActivite()
        {
          if (_context.Activite == null)
          {
              return NotFound();
          }
            return await _context.Activite.ToListAsync();
        }

        // GET: api/Activite/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Activite>> GetActivite(int id)
        {
          if (_context.Activite == null)
          {
              return NotFound();
          }
            var activite = await _context.Activite.FindAsync(id);

            if (activite == null)
            {
                return NotFound();
            }

            return activite;
        }

        // PUT: api/Activite/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutActivite(int id, Activite activite)
        {
            if (id != activite.ActiviteId)
            {
                return BadRequest();
            }

            _context.Entry(activite).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActiviteExists(id))
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

        // POST: api/Activite
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Activite>> PostActivite(Activite activite)
        {
          if (_context.Activite == null)
          {
              return Problem("Entity set 'FifaDbContext.Activite'  is null.");
          }
            _context.Activite.Add(activite);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetActivite", new { id = activite.ActiviteId }, activite);
        }

        // DELETE: api/Activite/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActivite(int id)
        {
            if (_context.Activite == null)
            {
                return NotFound();
            }
            var activite = await _context.Activite.FindAsync(id);
            if (activite == null)
            {
                return NotFound();
            }

            _context.Activite.Remove(activite);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ActiviteExists(int id)
        {
            return (_context.Activite?.Any(e => e.ActiviteId == id)).GetValueOrDefault();
        }
    }
}
