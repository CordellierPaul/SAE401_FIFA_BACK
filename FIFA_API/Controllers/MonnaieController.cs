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
    public class MonnaieController : ControllerBase
    {
        private readonly FifaDbContext _context;

        public MonnaieController(FifaDbContext context)
        {
            _context = context;
        }

        // GET: api/Monnaie
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Monnaie>>> GetMonnaie()
        {
          if (_context.Monnaie == null)
          {
              return NotFound();
          }
            return await _context.Monnaie.ToListAsync();
        }

        // GET: api/Monnaie/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Monnaie>> GetMonnaie(int id)
        {
          if (_context.Monnaie == null)
          {
              return NotFound();
          }
            var monnaie = await _context.Monnaie.FindAsync(id);

            if (monnaie == null)
            {
                return NotFound();
            }

            return monnaie;
        }

        // PUT: api/Monnaie/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMonnaie(int id, Monnaie monnaie)
        {
            if (id != monnaie.MonnaieId)
            {
                return BadRequest();
            }

            _context.Entry(monnaie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MonnaieExists(id))
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

        // POST: api/Monnaie
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Monnaie>> PostMonnaie(Monnaie monnaie)
        {
          if (_context.Monnaie == null)
          {
              return Problem("Entity set 'FifaDbContext.Monnaie'  is null.");
          }
            _context.Monnaie.Add(monnaie);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMonnaie", new { id = monnaie.MonnaieId }, monnaie);
        }

        // DELETE: api/Monnaie/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMonnaie(int id)
        {
            if (_context.Monnaie == null)
            {
                return NotFound();
            }
            var monnaie = await _context.Monnaie.FindAsync(id);
            if (monnaie == null)
            {
                return NotFound();
            }

            _context.Monnaie.Remove(monnaie);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MonnaieExists(int id)
        {
            return (_context.Monnaie?.Any(e => e.MonnaieId == id)).GetValueOrDefault();
        }
    }
}
