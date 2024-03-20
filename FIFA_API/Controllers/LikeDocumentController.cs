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
    public class LikeDocumentController : ControllerBase
    {
        private readonly FifaDbContext _context;

        public LikeDocumentController(FifaDbContext context)
        {
            _context = context;
        }

        // GET: api/LikeDocument
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LikeDocument>>> GetLikeDocument()
        {
          if (_context.LikeDocument == null)
          {
              return NotFound();
          }
            return await _context.LikeDocument.ToListAsync();
        }

        // GET: api/LikeDocument/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LikeDocument>> GetLikeDocument(int id)
        {
          if (_context.LikeDocument == null)
          {
              return NotFound();
          }
            var likeDocument = await _context.LikeDocument.FindAsync(id);

            if (likeDocument == null)
            {
                return NotFound();
            }

            return likeDocument;
        }

        // PUT: api/LikeDocument/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLikeDocument(int id, LikeDocument likeDocument)
        {
            if (id != likeDocument.DocumentId)
            {
                return BadRequest();
            }

            _context.Entry(likeDocument).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LikeDocumentExists(id))
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

        // POST: api/LikeDocument
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LikeDocument>> PostLikeDocument(LikeDocument likeDocument)
        {
          if (_context.LikeDocument == null)
          {
              return Problem("Entity set 'FifaDbContext.LikeDocument'  is null.");
          }
            _context.LikeDocument.Add(likeDocument);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (LikeDocumentExists(likeDocument.DocumentId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetLikeDocument", new { id = likeDocument.DocumentId }, likeDocument);
        }

        // DELETE: api/LikeDocument/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLikeDocument(int id)
        {
            if (_context.LikeDocument == null)
            {
                return NotFound();
            }
            var likeDocument = await _context.LikeDocument.FindAsync(id);
            if (likeDocument == null)
            {
                return NotFound();
            }

            _context.LikeDocument.Remove(likeDocument);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LikeDocumentExists(int id)
        {
            return (_context.LikeDocument?.Any(e => e.DocumentId == id)).GetValueOrDefault();
        }
    }
}
