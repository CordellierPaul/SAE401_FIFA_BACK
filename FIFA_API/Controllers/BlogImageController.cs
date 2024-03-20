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
    public class BlogImageController : ControllerBase
    {
        private readonly FifaDbContext _context;

        public BlogImageController(FifaDbContext context)
        {
            _context = context;
        }

        // GET: api/BlogImage
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BlogImage>>> GetBlogImage()
        {
          if (_context.BlogImage == null)
          {
              return NotFound();
          }
            return await _context.BlogImage.ToListAsync();
        }

        // GET: api/BlogImage/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BlogImage>> GetBlogImage(int id)
        {
          if (_context.BlogImage == null)
          {
              return NotFound();
          }
            var blogImage = await _context.BlogImage.FindAsync(id);

            if (blogImage == null)
            {
                return NotFound();
            }

            return blogImage;
        }

        // PUT: api/BlogImage/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBlogImage(int id, BlogImage blogImage)
        {
            if (id != blogImage.BlogId)
            {
                return BadRequest();
            }

            _context.Entry(blogImage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BlogImageExists(id))
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

        // POST: api/BlogImage
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BlogImage>> PostBlogImage(BlogImage blogImage)
        {
          if (_context.BlogImage == null)
          {
              return Problem("Entity set 'FifaDbContext.BlogImage'  is null.");
          }
            _context.BlogImage.Add(blogImage);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BlogImageExists(blogImage.BlogId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetBlogImage", new { id = blogImage.BlogId }, blogImage);
        }

        // DELETE: api/BlogImage/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBlogImage(int id)
        {
            if (_context.BlogImage == null)
            {
                return NotFound();
            }
            var blogImage = await _context.BlogImage.FindAsync(id);
            if (blogImage == null)
            {
                return NotFound();
            }

            _context.BlogImage.Remove(blogImage);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BlogImageExists(int id)
        {
            return (_context.BlogImage?.Any(e => e.BlogId == id)).GetValueOrDefault();
        }
    }
}
