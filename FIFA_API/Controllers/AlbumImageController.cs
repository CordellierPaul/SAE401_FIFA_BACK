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
    public class AlbumImageController : ControllerBase
    {
        private readonly FifaDbContext _context;

        public AlbumImageController(FifaDbContext context)
        {
            _context = context;
        }

        // GET: api/AlbumImage
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AlbumImage>>> GetAlbumImage()
        {
          if (_context.AlbumImage == null)
          {
              return NotFound();
          }
            return await _context.AlbumImage.ToListAsync();
        }

        // GET: api/AlbumImage/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AlbumImage>> GetAlbumImage(int id)
        {
          if (_context.AlbumImage == null)
          {
              return NotFound();
          }
            var albumImage = await _context.AlbumImage.FindAsync(id);

            if (albumImage == null)
            {
                return NotFound();
            }

            return albumImage;
        }

        // PUT: api/AlbumImage/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAlbumImage(int id, AlbumImage albumImage)
        {
            if (id != albumImage.AlbumId)
            {
                return BadRequest();
            }

            _context.Entry(albumImage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlbumImageExists(id))
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

        // POST: api/AlbumImage
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AlbumImage>> PostAlbumImage(AlbumImage albumImage)
        {
          if (_context.AlbumImage == null)
          {
              return Problem("Entity set 'FifaDbContext.AlbumImage'  is null.");
          }
            _context.AlbumImage.Add(albumImage);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AlbumImageExists(albumImage.AlbumId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAlbumImage", new { id = albumImage.AlbumId }, albumImage);
        }

        // DELETE: api/AlbumImage/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAlbumImage(int id)
        {
            if (_context.AlbumImage == null)
            {
                return NotFound();
            }
            var albumImage = await _context.AlbumImage.FindAsync(id);
            if (albumImage == null)
            {
                return NotFound();
            }

            _context.AlbumImage.Remove(albumImage);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AlbumImageExists(int id)
        {
            return (_context.AlbumImage?.Any(e => e.AlbumId == id)).GetValueOrDefault();
        }
    }
}
