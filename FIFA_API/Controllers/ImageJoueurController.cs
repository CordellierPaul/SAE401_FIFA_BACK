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
    public class ImageJoueurController : ControllerBase
    {
        private readonly FifaDbContext _context;

        public ImageJoueurController(FifaDbContext context)
        {
            _context = context;
        }

        // GET: api/ImageJoueur
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ImageJoueur>>> GetImageJoueur()
        {
          if (_context.ImageJoueur == null)
          {
              return NotFound();
          }
            return await _context.ImageJoueur.ToListAsync();
        }

        // GET: api/ImageJoueur/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ImageJoueur>> GetImageJoueur(int id)
        {
          if (_context.ImageJoueur == null)
          {
              return NotFound();
          }
            var imageJoueur = await _context.ImageJoueur.FindAsync(id);

            if (imageJoueur == null)
            {
                return NotFound();
            }

            return imageJoueur;
        }

        // PUT: api/ImageJoueur/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutImageJoueur(int id, ImageJoueur imageJoueur)
        {
            if (id != imageJoueur.ImageId)
            {
                return BadRequest();
            }

            _context.Entry(imageJoueur).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ImageJoueurExists(id))
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

        // POST: api/ImageJoueur
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ImageJoueur>> PostImageJoueur(ImageJoueur imageJoueur)
        {
          if (_context.ImageJoueur == null)
          {
              return Problem("Entity set 'FifaDbContext.ImageJoueur'  is null.");
          }
            _context.ImageJoueur.Add(imageJoueur);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ImageJoueurExists(imageJoueur.ImageId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetImageJoueur", new { id = imageJoueur.ImageId }, imageJoueur);
        }

        // DELETE: api/ImageJoueur/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteImageJoueur(int id)
        {
            if (_context.ImageJoueur == null)
            {
                return NotFound();
            }
            var imageJoueur = await _context.ImageJoueur.FindAsync(id);
            if (imageJoueur == null)
            {
                return NotFound();
            }

            _context.ImageJoueur.Remove(imageJoueur);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ImageJoueurExists(int id)
        {
            return (_context.ImageJoueur?.Any(e => e.ImageId == id)).GetValueOrDefault();
        }
    }
}
