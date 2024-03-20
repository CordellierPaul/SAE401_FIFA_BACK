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
    public class ProduitSimilaireController : ControllerBase
    {
        private readonly FifaDbContext _context;

        public ProduitSimilaireController(FifaDbContext context)
        {
            _context = context;
        }

        // GET: api/ProduitSimilaire
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProduitSimilaire>>> GetProduitSimilaire()
        {
          if (_context.ProduitSimilaire == null)
          {
              return NotFound();
          }
            return await _context.ProduitSimilaire.ToListAsync();
        }

        // GET: api/ProduitSimilaire/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProduitSimilaire>> GetProduitSimilaire(int id)
        {
          if (_context.ProduitSimilaire == null)
          {
              return NotFound();
          }
            var produitSimilaire = await _context.ProduitSimilaire.FindAsync(id);

            if (produitSimilaire == null)
            {
                return NotFound();
            }

            return produitSimilaire;
        }

        // PUT: api/ProduitSimilaire/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduitSimilaire(int id, ProduitSimilaire produitSimilaire)
        {
            if (id != produitSimilaire.ProduitUnId)
            {
                return BadRequest();
            }

            _context.Entry(produitSimilaire).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProduitSimilaireExists(id))
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

        // POST: api/ProduitSimilaire
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProduitSimilaire>> PostProduitSimilaire(ProduitSimilaire produitSimilaire)
        {
          if (_context.ProduitSimilaire == null)
          {
              return Problem("Entity set 'FifaDbContext.ProduitSimilaire'  is null.");
          }
            _context.ProduitSimilaire.Add(produitSimilaire);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ProduitSimilaireExists(produitSimilaire.ProduitUnId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetProduitSimilaire", new { id = produitSimilaire.ProduitUnId }, produitSimilaire);
        }

        // DELETE: api/ProduitSimilaire/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduitSimilaire(int id)
        {
            if (_context.ProduitSimilaire == null)
            {
                return NotFound();
            }
            var produitSimilaire = await _context.ProduitSimilaire.FindAsync(id);
            if (produitSimilaire == null)
            {
                return NotFound();
            }

            _context.ProduitSimilaire.Remove(produitSimilaire);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProduitSimilaireExists(int id)
        {
            return (_context.ProduitSimilaire?.Any(e => e.ProduitUnId == id)).GetValueOrDefault();
        }
    }
}
