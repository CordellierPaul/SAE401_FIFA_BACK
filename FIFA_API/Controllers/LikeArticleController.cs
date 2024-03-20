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
    public class LikeArticleController : ControllerBase
    {
        private readonly FifaDbContext _context;

        public LikeArticleController(FifaDbContext context)
        {
            _context = context;
        }

        // GET: api/LikeArticle
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LikeArticle>>> GetLikeArticle()
        {
          if (_context.LikeArticle == null)
          {
              return NotFound();
          }
            return await _context.LikeArticle.ToListAsync();
        }

        // GET: api/LikeArticle/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LikeArticle>> GetLikeArticle(int id)
        {
          if (_context.LikeArticle == null)
          {
              return NotFound();
          }
            var likeArticle = await _context.LikeArticle.FindAsync(id);

            if (likeArticle == null)
            {
                return NotFound();
            }

            return likeArticle;
        }

        // PUT: api/LikeArticle/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLikeArticle(int id, LikeArticle likeArticle)
        {
            if (id != likeArticle.ArticleId)
            {
                return BadRequest();
            }

            _context.Entry(likeArticle).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LikeArticleExists(id))
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

        // POST: api/LikeArticle
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LikeArticle>> PostLikeArticle(LikeArticle likeArticle)
        {
          if (_context.LikeArticle == null)
          {
              return Problem("Entity set 'FifaDbContext.LikeArticle'  is null.");
          }
            _context.LikeArticle.Add(likeArticle);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (LikeArticleExists(likeArticle.ArticleId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetLikeArticle", new { id = likeArticle.ArticleId }, likeArticle);
        }

        // DELETE: api/LikeArticle/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLikeArticle(int id)
        {
            if (_context.LikeArticle == null)
            {
                return NotFound();
            }
            var likeArticle = await _context.LikeArticle.FindAsync(id);
            if (likeArticle == null)
            {
                return NotFound();
            }

            _context.LikeArticle.Remove(likeArticle);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LikeArticleExists(int id)
        {
            return (_context.LikeArticle?.Any(e => e.ArticleId == id)).GetValueOrDefault();
        }
    }
}
