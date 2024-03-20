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
    public class VarianteProduitController : ControllerBase
    {
        private readonly FifaDbContext _context;

        public VarianteProduitController(FifaDbContext context)
        {
            _context = context;
        }

        // GET: api/VarianteProduit
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VarianteProduit>>> GetVarianteProduit()
        {
          if (_context.VarianteProduit == null)
          {
              return NotFound();
          }
            return await _context.VarianteProduit.ToListAsync();
        }

        // GET: api/VarianteProduit/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VarianteProduit>> GetVarianteProduit(int id)
        {
          if (_context.VarianteProduit == null)
          {
              return NotFound();
          }
            var varianteProduit = await _context.VarianteProduit.FindAsync(id);

            if (varianteProduit == null)
            {
                return NotFound();
            }

            return varianteProduit;
        }

        // PUT: api/VarianteProduit/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVarianteProduit(int id, VarianteProduit varianteProduit)
        {
            if (id != varianteProduit.VarianteProduitId)
            {
                return BadRequest();
            }

            _context.Entry(varianteProduit).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VarianteProduitExists(id))
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

        // POST: api/VarianteProduit
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<VarianteProduit>> PostVarianteProduit(VarianteProduit varianteProduit)
        {
          if (_context.VarianteProduit == null)
          {
              return Problem("Entity set 'FifaDbContext.VarianteProduit'  is null.");
          }
            _context.VarianteProduit.Add(varianteProduit);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVarianteProduit", new { id = varianteProduit.VarianteProduitId }, varianteProduit);
        }

        // DELETE: api/VarianteProduit/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVarianteProduit(int id)
        {
            if (_context.VarianteProduit == null)
            {
                return NotFound();
            }
            var varianteProduit = await _context.VarianteProduit.FindAsync(id);
            if (varianteProduit == null)
            {
                return NotFound();
            }

            _context.VarianteProduit.Remove(varianteProduit);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VarianteProduitExists(int id)
        {
            return (_context.VarianteProduit?.Any(e => e.VarianteProduitId == id)).GetValueOrDefault();
        }
    }
}
