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
    public class SousCategorieController : ControllerBase
    {
        private readonly FifaDbContext _context;

        public SousCategorieController(FifaDbContext context)
        {
            _context = context;
        }

        // GET: api/SousCategorie
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SousCategorie>>> GetSousCategorie()
        {
          if (_context.SousCategorie == null)
          {
              return NotFound();
          }
            return await _context.SousCategorie.ToListAsync();
        }

        // GET: api/SousCategorie/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SousCategorie>> GetSousCategorie(int id)
        {
          if (_context.SousCategorie == null)
          {
              return NotFound();
          }
            var sousCategorie = await _context.SousCategorie.FindAsync(id);

            if (sousCategorie == null)
            {
                return NotFound();
            }

            return sousCategorie;
        }

        // PUT: api/SousCategorie/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSousCategorie(int id, SousCategorie sousCategorie)
        {
            if (id != sousCategorie.CategorieParentId)
            {
                return BadRequest();
            }

            _context.Entry(sousCategorie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SousCategorieExists(id))
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

        // POST: api/SousCategorie
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SousCategorie>> PostSousCategorie(SousCategorie sousCategorie)
        {
          if (_context.SousCategorie == null)
          {
              return Problem("Entity set 'FifaDbContext.SousCategorie'  is null.");
          }
            _context.SousCategorie.Add(sousCategorie);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SousCategorieExists(sousCategorie.CategorieParentId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetSousCategorie", new { id = sousCategorie.CategorieParentId }, sousCategorie);
        }

        // DELETE: api/SousCategorie/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSousCategorie(int id)
        {
            if (_context.SousCategorie == null)
            {
                return NotFound();
            }
            var sousCategorie = await _context.SousCategorie.FindAsync(id);
            if (sousCategorie == null)
            {
                return NotFound();
            }

            _context.SousCategorie.Remove(sousCategorie);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SousCategorieExists(int id)
        {
            return (_context.SousCategorie?.Any(e => e.CategorieParentId == id)).GetValueOrDefault();
        }
    }
}
