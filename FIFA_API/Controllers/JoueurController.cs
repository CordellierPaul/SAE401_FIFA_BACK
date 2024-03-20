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
    public class JoueurController : ControllerBase
    {
        private readonly FifaDbContext _context;

        public JoueurController(FifaDbContext context)
        {
            _context = context;
        }

        // GET: api/Joueur
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Joueur>>> GetJoueur()
        {
          if (_context.Joueur == null)
          {
              return NotFound();
          }
            return await _context.Joueur.ToListAsync();
        }

        // GET: api/Joueur/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Joueur>> GetJoueur(int id)
        {
          if (_context.Joueur == null)
          {
              return NotFound();
          }
            var joueur = await _context.Joueur.FindAsync(id);

            if (joueur == null)
            {
                return NotFound();
            }

            return joueur;
        }

        // PUT: api/Joueur/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJoueur(int id, Joueur joueur)
        {
            if (id != joueur.JoueurId)
            {
                return BadRequest();
            }

            _context.Entry(joueur).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JoueurExists(id))
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

        // POST: api/Joueur
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Joueur>> PostJoueur(Joueur joueur)
        {
          if (_context.Joueur == null)
          {
              return Problem("Entity set 'FifaDbContext.Joueur'  is null.");
          }
            _context.Joueur.Add(joueur);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetJoueur", new { id = joueur.JoueurId }, joueur);
        }

        // DELETE: api/Joueur/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJoueur(int id)
        {
            if (_context.Joueur == null)
            {
                return NotFound();
            }
            var joueur = await _context.Joueur.FindAsync(id);
            if (joueur == null)
            {
                return NotFound();
            }

            _context.Joueur.Remove(joueur);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool JoueurExists(int id)
        {
            return (_context.Joueur?.Any(e => e.JoueurId == id)).GetValueOrDefault();
        }
    }
}
