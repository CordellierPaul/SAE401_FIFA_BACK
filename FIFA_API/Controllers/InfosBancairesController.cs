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
    public class InfosBancairesController : ControllerBase
    {
        private readonly FifaDbContext _context;

        public InfosBancairesController(FifaDbContext context)
        {
            _context = context;
        }

        // GET: api/InfosBancaires
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InfosBancaires>>> GetInfosBancaires()
        {
          if (_context.InfosBancaires == null)
          {
              return NotFound();
          }
            return await _context.InfosBancaires.ToListAsync();
        }

        // GET: api/InfosBancaires/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InfosBancaires>> GetInfosBancaires(int id)
        {
          if (_context.InfosBancaires == null)
          {
              return NotFound();
          }
            var infosBancaires = await _context.InfosBancaires.FindAsync(id);

            if (infosBancaires == null)
            {
                return NotFound();
            }

            return infosBancaires;
        }

        // PUT: api/InfosBancaires/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInfosBancaires(int id, InfosBancaires infosBancaires)
        {
            if (id != infosBancaires.InfosBancairesId)
            {
                return BadRequest();
            }

            _context.Entry(infosBancaires).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InfosBancairesExists(id))
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

        // POST: api/InfosBancaires
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<InfosBancaires>> PostInfosBancaires(InfosBancaires infosBancaires)
        {
          if (_context.InfosBancaires == null)
          {
              return Problem("Entity set 'FifaDbContext.InfosBancaires'  is null.");
          }
            _context.InfosBancaires.Add(infosBancaires);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (InfosBancairesExists(infosBancaires.InfosBancairesId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetInfosBancaires", new { id = infosBancaires.InfosBancairesId }, infosBancaires);
        }

        // DELETE: api/InfosBancaires/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInfosBancaires(int id)
        {
            if (_context.InfosBancaires == null)
            {
                return NotFound();
            }
            var infosBancaires = await _context.InfosBancaires.FindAsync(id);
            if (infosBancaires == null)
            {
                return NotFound();
            }

            _context.InfosBancaires.Remove(infosBancaires);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InfosBancairesExists(int id)
        {
            return (_context.InfosBancaires?.Any(e => e.InfosBancairesId == id)).GetValueOrDefault();
        }
    }
}
