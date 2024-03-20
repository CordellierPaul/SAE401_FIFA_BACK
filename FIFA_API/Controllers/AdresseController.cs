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
    public class AdresseController : ControllerBase
    {
        private readonly FifaDbContext _context;

        public AdresseController(FifaDbContext context)
        {
            _context = context;
        }

        // GET: api/Adresse
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Adresse>>> GetAdresse()
        {
          if (_context.Adresse == null)
          {
              return NotFound();
          }
            return await _context.Adresse.ToListAsync();
        }

        // GET: api/Adresse/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Adresse>> GetAdresse(int id)
        {
          if (_context.Adresse == null)
          {
              return NotFound();
          }
            var adresse = await _context.Adresse.FindAsync(id);

            if (adresse == null)
            {
                return NotFound();
            }

            return adresse;
        }

        // PUT: api/Adresse/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdresse(int id, Adresse adresse)
        {
            if (id != adresse.AdresseId)
            {
                return BadRequest();
            }

            _context.Entry(adresse).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdresseExists(id))
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

        // POST: api/Adresse
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Adresse>> PostAdresse(Adresse adresse)
        {
          if (_context.Adresse == null)
          {
              return Problem("Entity set 'FifaDbContext.Adresse'  is null.");
          }
            _context.Adresse.Add(adresse);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAdresse", new { id = adresse.AdresseId }, adresse);
        }

        // DELETE: api/Adresse/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdresse(int id)
        {
            if (_context.Adresse == null)
            {
                return NotFound();
            }
            var adresse = await _context.Adresse.FindAsync(id);
            if (adresse == null)
            {
                return NotFound();
            }

            _context.Adresse.Remove(adresse);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AdresseExists(int id)
        {
            return (_context.Adresse?.Any(e => e.AdresseId == id)).GetValueOrDefault();
        }
    }
}
