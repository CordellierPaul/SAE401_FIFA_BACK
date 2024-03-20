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
    public class VilleController : ControllerBase
    {
        private readonly FifaDbContext _context;

        public VilleController(FifaDbContext context)
        {
            _context = context;
        }

        // GET: api/Ville
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ville>>> GetVille()
        {
          if (_context.Ville == null)
          {
              return NotFound();
          }
            return await _context.Ville.ToListAsync();
        }

        // GET: api/Ville/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ville>> GetVille(int id)
        {
          if (_context.Ville == null)
          {
              return NotFound();
          }
            var ville = await _context.Ville.FindAsync(id);

            if (ville == null)
            {
                return NotFound();
            }

            return ville;
        }

        // PUT: api/Ville/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVille(int id, Ville ville)
        {
            if (id != ville.VilleId)
            {
                return BadRequest();
            }

            _context.Entry(ville).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VilleExists(id))
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

        // POST: api/Ville
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Ville>> PostVille(Ville ville)
        {
          if (_context.Ville == null)
          {
              return Problem("Entity set 'FifaDbContext.Ville'  is null.");
          }
            _context.Ville.Add(ville);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVille", new { id = ville.VilleId }, ville);
        }

        // DELETE: api/Ville/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVille(int id)
        {
            if (_context.Ville == null)
            {
                return NotFound();
            }
            var ville = await _context.Ville.FindAsync(id);
            if (ville == null)
            {
                return NotFound();
            }

            _context.Ville.Remove(ville);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VilleExists(int id)
        {
            return (_context.Ville?.Any(e => e.VilleId == id)).GetValueOrDefault();
        }
    }
}
