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
    public class CaracteristiqueController : ControllerBase
    {
        private readonly FifaDbContext _context;

        public CaracteristiqueController(FifaDbContext context)
        {
            _context = context;
        }

        // GET: api/Caracteristique
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Caracteristique>>> GetCaracteristique()
        {
          if (_context.Caracteristique == null)
          {
              return NotFound();
          }
            return await _context.Caracteristique.ToListAsync();
        }

        // GET: api/Caracteristique/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Caracteristique>> GetCaracteristique(int id)
        {
          if (_context.Caracteristique == null)
          {
              return NotFound();
          }
            var caracteristique = await _context.Caracteristique.FindAsync(id);

            if (caracteristique == null)
            {
                return NotFound();
            }

            return caracteristique;
        }

        // PUT: api/Caracteristique/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCaracteristique(int id, Caracteristique caracteristique)
        {
            if (id != caracteristique.CaracteristiqueId)
            {
                return BadRequest();
            }

            _context.Entry(caracteristique).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CaracteristiqueExists(id))
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

        // POST: api/Caracteristique
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Caracteristique>> PostCaracteristique(Caracteristique caracteristique)
        {
          if (_context.Caracteristique == null)
          {
              return Problem("Entity set 'FifaDbContext.Caracteristique'  is null.");
          }
            _context.Caracteristique.Add(caracteristique);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCaracteristique", new { id = caracteristique.CaracteristiqueId }, caracteristique);
        }

        // DELETE: api/Caracteristique/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCaracteristique(int id)
        {
            if (_context.Caracteristique == null)
            {
                return NotFound();
            }
            var caracteristique = await _context.Caracteristique.FindAsync(id);
            if (caracteristique == null)
            {
                return NotFound();
            }

            _context.Caracteristique.Remove(caracteristique);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CaracteristiqueExists(int id)
        {
            return (_context.Caracteristique?.Any(e => e.CaracteristiqueId == id)).GetValueOrDefault();
        }
    }
}
