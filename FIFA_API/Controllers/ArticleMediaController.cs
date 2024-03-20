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
    public class ArticleMediaController : ControllerBase
    {
        private readonly FifaDbContext _context;

        public ArticleMediaController(FifaDbContext context)
        {
            _context = context;
        }

        // GET: api/ArticleMedia
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ArticleMedia>>> GetArticleMedia()
        {
          if (_context.ArticleMedia == null)
          {
              return NotFound();
          }
            return await _context.ArticleMedia.ToListAsync();
        }

        // GET: api/ArticleMedia/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ArticleMedia>> GetArticleMedia(int id)
        {
          if (_context.ArticleMedia == null)
          {
              return NotFound();
          }
            var articleMedia = await _context.ArticleMedia.FindAsync(id);

            if (articleMedia == null)
            {
                return NotFound();
            }

            return articleMedia;
        }

        // PUT: api/ArticleMedia/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArticleMedia(int id, ArticleMedia articleMedia)
        {
            if (id != articleMedia.ArticleId)
            {
                return BadRequest();
            }

            _context.Entry(articleMedia).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArticleMediaExists(id))
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

        // POST: api/ArticleMedia
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ArticleMedia>> PostArticleMedia(ArticleMedia articleMedia)
        {
          if (_context.ArticleMedia == null)
          {
              return Problem("Entity set 'FifaDbContext.ArticleMedia'  is null.");
          }
            _context.ArticleMedia.Add(articleMedia);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ArticleMediaExists(articleMedia.ArticleId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetArticleMedia", new { id = articleMedia.ArticleId }, articleMedia);
        }

        // DELETE: api/ArticleMedia/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArticleMedia(int id)
        {
            if (_context.ArticleMedia == null)
            {
                return NotFound();
            }
            var articleMedia = await _context.ArticleMedia.FindAsync(id);
            if (articleMedia == null)
            {
                return NotFound();
            }

            _context.ArticleMedia.Remove(articleMedia);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ArticleMediaExists(int id)
        {
            return (_context.ArticleMedia?.Any(e => e.ArticleId == id)).GetValueOrDefault();
        }
    }
}
