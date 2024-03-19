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
    public class CompteController : ControllerBase
    {
        private readonly FifaDbContext _context;

        public CompteController(FifaDbContext context)
        {
            _context = context;
        }

        // GET: api/Compte
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Compte>>> GetCompte()
        {
          if (_context.Compte == null)
          {
              return NotFound();
          }
            return await _context.Compte.ToListAsync();
        }

        // GET: api/Compte/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Compte>> GetCompte(int id)
        {
          if (_context.Compte == null)
          {
              return NotFound();
          }
            var compte = await _context.Compte.FindAsync(id);

            if (compte == null)
            {
                return NotFound();
            }

            return compte;
        }

        // PUT: api/Compte/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompte(int id, Compte compte)
        {
            if (id != compte.CompteId)
            {
                return BadRequest();
            }

            _context.Entry(compte).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompteExists(id))
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

        // POST: api/Compte
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Compte>> PostCompte(Compte compte)
        {
          if (_context.Compte == null)
          {
              return Problem("Entity set 'FifaDbContext.Compte'  is null.");
          }
            _context.Compte.Add(compte);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCompte", new { id = compte.CompteId }, compte);
        }

        // DELETE: api/Compte/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompte(int id)
        {
            if (_context.Compte == null)
            {
                return NotFound();
            }
            var compte = await _context.Compte.FindAsync(id);
            if (compte == null)
            {
                return NotFound();
            }

            _context.Compte.Remove(compte);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CompteExists(int id)
        {
            return (_context.Compte?.Any(e => e.CompteId == id)).GetValueOrDefault();
        }
    }
}
