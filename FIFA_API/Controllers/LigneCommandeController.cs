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
    public class LigneCommandeController : ControllerBase
    {
        private readonly FifaDbContext _context;

        public LigneCommandeController(FifaDbContext context)
        {
            _context = context;
        }

        // GET: api/LigneCommande
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LigneCommande>>> GetLigneCommande()
        {
          if (_context.LigneCommande == null)
          {
              return NotFound();
          }
            return await _context.LigneCommande.ToListAsync();
        }

        // GET: api/LigneCommande/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LigneCommande>> GetLigneCommande(int id)
        {
          if (_context.LigneCommande == null)
          {
              return NotFound();
          }
            var ligneCommande = await _context.LigneCommande.FindAsync(id);

            if (ligneCommande == null)
            {
                return NotFound();
            }

            return ligneCommande;
        }

        // PUT: api/LigneCommande/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLigneCommande(int id, LigneCommande ligneCommande)
        {
            if (id != ligneCommande.LigneCommandeId)
            {
                return BadRequest();
            }

            _context.Entry(ligneCommande).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LigneCommandeExists(id))
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

        // POST: api/LigneCommande
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LigneCommande>> PostLigneCommande(LigneCommande ligneCommande)
        {
          if (_context.LigneCommande == null)
          {
              return Problem("Entity set 'FifaDbContext.LigneCommande'  is null.");
          }
            _context.LigneCommande.Add(ligneCommande);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLigneCommande", new { id = ligneCommande.LigneCommandeId }, ligneCommande);
        }

        // DELETE: api/LigneCommande/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLigneCommande(int id)
        {
            if (_context.LigneCommande == null)
            {
                return NotFound();
            }
            var ligneCommande = await _context.LigneCommande.FindAsync(id);
            if (ligneCommande == null)
            {
                return NotFound();
            }

            _context.LigneCommande.Remove(ligneCommande);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LigneCommandeExists(int id)
        {
            return (_context.LigneCommande?.Any(e => e.LigneCommandeId == id)).GetValueOrDefault();
        }
    }
}
