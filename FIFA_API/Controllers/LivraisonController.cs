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
    public class LivraisonController : ControllerBase
    {
        private readonly FifaDbContext _context;

        public LivraisonController(FifaDbContext context)
        {
            _context = context;
        }

        // GET: api/Livraison
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Livraison>>> GetLivraison()
        {
          if (_context.Livraison == null)
          {
              return NotFound();
          }
            return await _context.Livraison.ToListAsync();
        }

        // GET: api/Livraison/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Livraison>> GetLivraison(int id)
        {
          if (_context.Livraison == null)
          {
              return NotFound();
          }
            var livraison = await _context.Livraison.FindAsync(id);

            if (livraison == null)
            {
                return NotFound();
            }

            return livraison;
        }

        // PUT: api/Livraison/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLivraison(int id, Livraison livraison)
        {
            if (id != livraison.LivraisonId)
            {
                return BadRequest();
            }

            _context.Entry(livraison).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LivraisonExists(id))
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

        // POST: api/Livraison
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Livraison>> PostLivraison(Livraison livraison)
        {
          if (_context.Livraison == null)
          {
              return Problem("Entity set 'FifaDbContext.Livraison'  is null.");
          }
            _context.Livraison.Add(livraison);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLivraison", new { id = livraison.LivraisonId }, livraison);
        }

        // DELETE: api/Livraison/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLivraison(int id)
        {
            if (_context.Livraison == null)
            {
                return NotFound();
            }
            var livraison = await _context.Livraison.FindAsync(id);
            if (livraison == null)
            {
                return NotFound();
            }

            _context.Livraison.Remove(livraison);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LivraisonExists(int id)
        {
            return (_context.Livraison?.Any(e => e.LivraisonId == id)).GetValueOrDefault();
        }
    }
}
