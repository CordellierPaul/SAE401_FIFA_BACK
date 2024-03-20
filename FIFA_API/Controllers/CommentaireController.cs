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
    public class CommentaireController : ControllerBase
    {
        private readonly FifaDbContext _context;

        public CommentaireController(FifaDbContext context)
        {
            _context = context;
        }

        // GET: api/Command
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Commentaire>>> GetCommentaire()
        {
          if (_context.Commentaire == null)
          {
              return NotFound();
          }
            return await _context.Commentaire.ToListAsync();
        }

        // GET: api/Command/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Commentaire>> GetCommentaire(int id)
        {
          if (_context.Commentaire == null)
          {
              return NotFound();
          }
            var commentaire = await _context.Commentaire.FindAsync(id);

            if (commentaire == null)
            {
                return NotFound();
            }

            return commentaire;
        }

        // PUT: api/Command/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCommentaire(int id, Commentaire commentaire)
        {
            if (id != commentaire.CommentaireId)
            {
                return BadRequest();
            }

            _context.Entry(commentaire).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommentaireExists(id))
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

        // POST: api/Command
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Commentaire>> PostCommentaire(Commentaire commentaire)
        {
          if (_context.Commentaire == null)
          {
              return Problem("Entity set 'FifaDbContext.Commentaire'  is null.");
          }
            _context.Commentaire.Add(commentaire);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCommentaire", new { id = commentaire.CommentaireId }, commentaire);
        }

        // DELETE: api/Command/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCommentaire(int id)
        {
            if (_context.Commentaire == null)
            {
                return NotFound();
            }
            var commentaire = await _context.Commentaire.FindAsync(id);
            if (commentaire == null)
            {
                return NotFound();
            }

            _context.Commentaire.Remove(commentaire);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CommentaireExists(int id)
        {
            return (_context.Commentaire?.Any(e => e.CommentaireId == id)).GetValueOrDefault();
        }
    }
}
