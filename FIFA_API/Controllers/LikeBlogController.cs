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
    public class LikeBlogController : ControllerBase
    {
        private readonly FifaDbContext _context;

        public LikeBlogController(FifaDbContext context)
        {
            _context = context;
        }

        // GET: api/LikeBlog
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LikeBlog>>> GetLikeBlog()
        {
          if (_context.LikeBlog == null)
          {
              return NotFound();
          }
            return await _context.LikeBlog.ToListAsync();
        }

        // GET: api/LikeBlog/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LikeBlog>> GetLikeBlog(int id)
        {
          if (_context.LikeBlog == null)
          {
              return NotFound();
          }
            var likeBlog = await _context.LikeBlog.FindAsync(id);

            if (likeBlog == null)
            {
                return NotFound();
            }

            return likeBlog;
        }

        // PUT: api/LikeBlog/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLikeBlog(int id, LikeBlog likeBlog)
        {
            if (id != likeBlog.BlogId)
            {
                return BadRequest();
            }

            _context.Entry(likeBlog).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LikeBlogExists(id))
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

        // POST: api/LikeBlog
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LikeBlog>> PostLikeBlog(LikeBlog likeBlog)
        {
          if (_context.LikeBlog == null)
          {
              return Problem("Entity set 'FifaDbContext.LikeBlog'  is null.");
          }
            _context.LikeBlog.Add(likeBlog);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (LikeBlogExists(likeBlog.BlogId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetLikeBlog", new { id = likeBlog.BlogId }, likeBlog);
        }

        // DELETE: api/LikeBlog/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLikeBlog(int id)
        {
            if (_context.LikeBlog == null)
            {
                return NotFound();
            }
            var likeBlog = await _context.LikeBlog.FindAsync(id);
            if (likeBlog == null)
            {
                return NotFound();
            }

            _context.LikeBlog.Remove(likeBlog);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LikeBlogExists(int id)
        {
            return (_context.LikeBlog?.Any(e => e.BlogId == id)).GetValueOrDefault();
        }
    }
}
