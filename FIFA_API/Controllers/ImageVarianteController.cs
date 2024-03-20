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
    public class ImageVarianteController : ControllerBase
    {
        private readonly FifaDbContext _context;

        public ImageVarianteController(FifaDbContext context)
        {
            _context = context;
        }

        // GET: api/ImageVariante
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ImageVariante>>> GetImageVariante()
        {
          if (_context.ImageVariante == null)
          {
              return NotFound();
          }
            return await _context.ImageVariante.ToListAsync();
        }

        // GET: api/ImageVariante/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ImageVariante>> GetImageVariante(int id)
        {
          if (_context.ImageVariante == null)
          {
              return NotFound();
          }
            var imageVariante = await _context.ImageVariante.FindAsync(id);

            if (imageVariante == null)
            {
                return NotFound();
            }

            return imageVariante;
        }

        // PUT: api/ImageVariante/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutImageVariante(int id, ImageVariante imageVariante)
        {
            if (id != imageVariante.ImageId)
            {
                return BadRequest();
            }

            _context.Entry(imageVariante).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ImageVarianteExists(id))
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

        // POST: api/ImageVariante
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ImageVariante>> PostImageVariante(ImageVariante imageVariante)
        {
          if (_context.ImageVariante == null)
          {
              return Problem("Entity set 'FifaDbContext.ImageVariante'  is null.");
          }
            _context.ImageVariante.Add(imageVariante);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ImageVarianteExists(imageVariante.ImageId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetImageVariante", new { id = imageVariante.ImageId }, imageVariante);
        }

        // DELETE: api/ImageVariante/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteImageVariante(int id)
        {
            if (_context.ImageVariante == null)
            {
                return NotFound();
            }
            var imageVariante = await _context.ImageVariante.FindAsync(id);
            if (imageVariante == null)
            {
                return NotFound();
            }

            _context.ImageVariante.Remove(imageVariante);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ImageVarianteExists(int id)
        {
            return (_context.ImageVariante?.Any(e => e.ImageId == id)).GetValueOrDefault();
        }
    }
}
