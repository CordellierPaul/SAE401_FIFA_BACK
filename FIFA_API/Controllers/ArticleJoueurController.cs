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
    public class ArticleJoueurController : ControllerBase
    {
        private readonly FifaDbContext _context;

        public ArticleJoueurController(FifaDbContext context)
        {
            _context = context;
        }

        // GET: api/ArticleJoueur
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ArticleJoueur>>> GetArticleJoueur()
        {
          if (_context.ArticleJoueur == null)
          {
              return NotFound();
          }
            return await _context.ArticleJoueur.ToListAsync();
        }

        // GET: api/ArticleJoueur/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ArticleJoueur>> GetArticleJoueur(int id)
        {
          if (_context.ArticleJoueur == null)
          {
              return NotFound();
          }
            var articleJoueur = await _context.ArticleJoueur.FindAsync(id);

            if (articleJoueur == null)
            {
                return NotFound();
            }

            return articleJoueur;
        }

        // PUT: api/ArticleJoueur/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArticleJoueur(int id, ArticleJoueur articleJoueur)
        {
            if (id != articleJoueur.ArticleId)
            {
                return BadRequest();
            }

            _context.Entry(articleJoueur).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArticleJoueurExists(id))
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

        // POST: api/ArticleJoueur
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ArticleJoueur>> PostArticleJoueur(ArticleJoueur articleJoueur)
        {
          if (_context.ArticleJoueur == null)
          {
              return Problem("Entity set 'FifaDbContext.ArticleJoueur'  is null.");
          }
            _context.ArticleJoueur.Add(articleJoueur);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ArticleJoueurExists(articleJoueur.ArticleId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetArticleJoueur", new { id = articleJoueur.ArticleId }, articleJoueur);
        }

        // DELETE: api/ArticleJoueur/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArticleJoueur(int id)
        {
            if (_context.ArticleJoueur == null)
            {
                return NotFound();
            }
            var articleJoueur = await _context.ArticleJoueur.FindAsync(id);
            if (articleJoueur == null)
            {
                return NotFound();
            }

            _context.ArticleJoueur.Remove(articleJoueur);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ArticleJoueurExists(int id)
        {
            return (_context.ArticleJoueur?.Any(e => e.ArticleId == id)).GetValueOrDefault();
        }
    }
}
