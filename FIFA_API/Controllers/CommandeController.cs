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
    public class CommandeController : ControllerBase
    {
        private readonly FifaDbContext _context;

        public CommandeController(FifaDbContext context)
        {
            _context = context;
        }

        // GET: api/Commande
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Commande>>> GetCommande()
        {
          if (_context.Commande == null)
          {
              return NotFound();
          }
            return await _context.Commande.ToListAsync();
        }

        // GET: api/Commande/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Commande>> GetCommande(int id)
        {
          if (_context.Commande == null)
          {
              return NotFound();
          }
            var commande = await _context.Commande.FindAsync(id);

            if (commande == null)
            {
                return NotFound();
            }

            return commande;
        }

        // PUT: api/Commande/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCommande(int id, Commande commande)
        {
            if (id != commande.CommandeId)
            {
                return BadRequest();
            }

            _context.Entry(commande).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommandeExists(id))
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

        // POST: api/Commande
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Commande>> PostCommande(Commande commande)
        {
          if (_context.Commande == null)
          {
              return Problem("Entity set 'FifaDbContext.Commande'  is null.");
          }
            _context.Commande.Add(commande);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCommande", new { id = commande.CommandeId }, commande);
        }

        // DELETE: api/Commande/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCommande(int id)
        {
            if (_context.Commande == null)
            {
                return NotFound();
            }
            var commande = await _context.Commande.FindAsync(id);
            if (commande == null)
            {
                return NotFound();
            }

            _context.Commande.Remove(commande);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CommandeExists(int id)
        {
            return (_context.Commande?.Any(e => e.CommandeId == id)).GetValueOrDefault();
        }
    }
}
