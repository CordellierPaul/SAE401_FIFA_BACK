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
    public class LikeAlbumController : ControllerBase
    {
        private readonly FifaDbContext _context;

        public LikeAlbumController(FifaDbContext context)
        {
            _context = context;
        }

        // GET: api/LikeAlbum
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LikeAlbum>>> GetLikeAlbum()
        {
          if (_context.LikeAlbum == null)
          {
              return NotFound();
          }
            return await _context.LikeAlbum.ToListAsync();
        }

        // GET: api/LikeAlbum/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LikeAlbum>> GetLikeAlbum(int id)
        {
          if (_context.LikeAlbum == null)
          {
              return NotFound();
          }
            var likeAlbum = await _context.LikeAlbum.FindAsync(id);

            if (likeAlbum == null)
            {
                return NotFound();
            }

            return likeAlbum;
        }

        // PUT: api/LikeAlbum/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLikeAlbum(int id, LikeAlbum likeAlbum)
        {
            if (id != likeAlbum.AlbumId)
            {
                return BadRequest();
            }

            _context.Entry(likeAlbum).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LikeAlbumExists(id))
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

        // POST: api/LikeAlbum
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LikeAlbum>> PostLikeAlbum(LikeAlbum likeAlbum)
        {
          if (_context.LikeAlbum == null)
          {
              return Problem("Entity set 'FifaDbContext.LikeAlbum'  is null.");
          }
            _context.LikeAlbum.Add(likeAlbum);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (LikeAlbumExists(likeAlbum.AlbumId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetLikeAlbum", new { id = likeAlbum.AlbumId }, likeAlbum);
        }

        // DELETE: api/LikeAlbum/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLikeAlbum(int id)
        {
            if (_context.LikeAlbum == null)
            {
                return NotFound();
            }
            var likeAlbum = await _context.LikeAlbum.FindAsync(id);
            if (likeAlbum == null)
            {
                return NotFound();
            }

            _context.LikeAlbum.Remove(likeAlbum);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LikeAlbumExists(int id)
        {
            return (_context.LikeAlbum?.Any(e => e.AlbumId == id)).GetValueOrDefault();
        }
    }
}
